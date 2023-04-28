using Easyfood.Application.Abstractions.Persistence;
using Easyfood.Domain.Abstractions.Repositories;
using Easyfood.Domain.Entities;
using Easyfood.Domain.Exceptions;
using Easyfood.Domain.ValueObjects;
using FluentValidation;
using MediatR;

namespace Easyfood.Application.Features.Customers.Commands.CreateCreditCard
{
    public record CreateCustomerCreditCardDto(Guid customerId,
        string Number,
        string CardholderFirstName,
        string CardholderLastName,
        string ExpirationDate,
        string CVCCode);

    public record CreateCustomerCreditCardCommand(Guid CustomerId,
        string Number,
        string CardholderFirstName,
        string CardholderLastName,
        string ExpirationDate,
        string CVCCode) : IRequest;

    public class CreateCustomerCreditCardCommandValidator : AbstractValidator<CreateCustomerCreditCardCommand>
    {
        public CreateCustomerCreditCardCommandValidator()
        {
            RuleFor(x => x.Number)
                .NotEmpty()
                .Must(x =>
                {
                    var number = x.Replace("-", "");
                    return number.Length >= 13 && number.Length <= 19;
                })
                .WithMessage("Invalid Credit Card Number length.");

            RuleFor(x => x.CardholderFirstName)
                .NotEmpty()
                .MinimumLength(Name.MIN_LENGTH)
                .MaximumLength(Name.MAX_LENGTH)
                .WithMessage("Invalid Cardholder First Name.");

            RuleFor(x => x.CardholderLastName)
                .NotEmpty()
                .MinimumLength(Name.MIN_LENGTH)
                .MaximumLength(Name.MAX_LENGTH)
                .WithMessage("Invalid Cardholder Last Name.");

            RuleFor(x => x.ExpirationDate)
                .NotEmpty()
                .Length(CreditCardExpDate.LENGTH)
                .WithMessage("Invalid Expiration Date.");

            RuleFor(x => x.CVCCode)
                .NotEmpty()
                .Length(CreditCardCVCCode.LENGTH)
                .WithMessage("Invalid CVC Code.");
        }
    }

    public class CreateCustomerCreditCardCommandHandler : IRequestHandler<CreateCustomerCreditCardCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCreditCardCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateCustomerCreditCardCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId,
                cancellationToken,
                x => x.CreditCards);

            if (customer == null)
                throw new DomainException("Customer not found");

            var creditCard = new CreditCard(request.Number,
                request.CVCCode,
                request.ExpirationDate,
                request.CardholderFirstName,
                request.CardholderLastName);

            customer.RegisterCreditCard(creditCard);

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}