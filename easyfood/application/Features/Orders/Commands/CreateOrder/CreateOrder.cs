using Easyfood.Application.Abstractions.Persistence;
using Easyfood.Application.Models;
using Easyfood.Domain.Abstractions.Repositories;
using Easyfood.Domain.Entities.Customers;
using Easyfood.Domain.Entities.Orders;
using Easyfood.Domain.Entities.Partners;
using Easyfood.Shared.Common.Response;
using FluentValidation;
using MediatR;
using System.Diagnostics.CodeAnalysis;

namespace Easyfood.Application.Features.Orders.Commands.CreateOrder
{
    public record CreateOrderDto(Guid CustomerId, Guid PartnerId, Guid CreditCardId, ItemSummaryDto[] Items);

    public record ItemSummaryDto(Guid ItemId, int Quantity);

    public record CreateOrderCommand(Guid CustomerId, Guid PartnerId, Guid CreditCardId, ItemSummaryDto[] Items) : IRequest<ResponseData<string>>;

    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .WithMessage("Invalid Customer.");

            RuleFor(x => x.PartnerId)
                .NotEmpty()
                .WithMessage("Invalid Partner.");

            RuleFor(x => x.CreditCardId)
                .NotEmpty()
                .WithMessage("Invalid Credit Card.");

            RuleFor(x => x.Items)
                .NotEmpty()
                .WithMessage("Invalid Items");
        }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ResponseData<string>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IPartnerRepository _partnerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderCommandHandler(ICustomerRepository customerRepository,
            IPartnerRepository partnerRepository,
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _partnerRepository = partnerRepository;
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseData<string>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId, cancellationToken, x => x.CreditCards);
            var partner = await _partnerRepository.GetByIdAsync(request.PartnerId, cancellationToken, x => x.Menu!.Items);

            var result = CheckErrors(customer, request, partner);

            if (result.HasErrors)
            {
                throw new ValidationException(result.ConcatenatedErrors());
            }

            return await CreateOrder(customer, partner, request, cancellationToken);
        }

        private async Task<ResponseData<string>> CreateOrder([NotNull] Customer? customer,
            [NotNull] Partner? partner,
            CreateOrderCommand request,
            CancellationToken cancellatioNToken)
        {
            var orderBuilder = OrderBuilder.CreateOrder(customer!.Id, partner!.Id);

            foreach (var orderItem in request.Items)
            {
                var menuItem = partner.Menu!.Items.First(x => x.Id == orderItem.ItemId);
                orderBuilder = orderBuilder.AddItem(menuItem.Id, orderItem.Quantity, menuItem.Price);
            }

            var order = orderBuilder.Create();

            _orderRepository.Insert(order);
            await _unitOfWork.SaveChangesAsync(cancellatioNToken);

            return new ResponseData<string>(order.OrderNumberDisplay);
        }

        public ValidationResult CheckErrors(Customer? customer, CreateOrderCommand request, Partner? partner)
        {
            var result = new ValidationResult();

            if (customer == null)
            {
                result.AddError("Invalid Customer.");
                return result;
            }

            if (partner == null || partner.Menu == null || partner.Menu.Items == null)
            {
                result.AddError("Invalid Partner.");
                return result;
            }

            if (!customer.HasCreditCard(request.CreditCardId))
            {
                result.AddError("Invalid Credit Card.");
                return result;
            }

            var orderItemsId = request.Items.Select(x => x.ItemId);
            var orderHasValidItems = partner.Menu.HasMenuItems(orderItemsId.ToList());

            if (!orderHasValidItems)
            {
                result.AddError("Invalid Order Items.");
            }

            return result;
        }
    }
}