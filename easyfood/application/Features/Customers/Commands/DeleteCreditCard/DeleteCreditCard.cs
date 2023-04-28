using Easyfood.Application.Abstractions.Persistence;
using Easyfood.Domain.Abstractions.Repositories;
using Easyfood.Domain.Exceptions;
using FluentValidation;
using MediatR;

namespace Easyfood.Application.Features.Customers.Commands.DeleteCreditCard
{
    public record DeleteCreditCardCommand(Guid CustomerId, Guid CreditCardId) : IRequest;

    public class DeleteCreditCardCommandValidator : AbstractValidator<DeleteCreditCardCommand>
    {
        public DeleteCreditCardCommandValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .WithMessage("Invalid Customer.");

            RuleFor(x => x.CreditCardId)
                .NotEmpty()
                .WithMessage("Invalid Credit Card.");
        }
    }

    public class DeleteCreditCardCommandHandler : IRequestHandler<DeleteCreditCardCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCreditCardCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCreditCardCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId, cancellationToken, x => x.CreditCards);

            if (customer == null)
                throw new DomainException("Customer not found.");

            customer.UnregisterCreditCard(request.CreditCardId);

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}