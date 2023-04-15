using Easyfood.Application.Abstractions.Persistence;
using Easyfood.Domain.Abstractions.Repositories;
using Easyfood.Domain.Entities;
using FluentValidation;
using MediatR;

namespace Easyfood.Application.Features.Customers.Commands.CreateNewCustomer
{
    public record CreateNewCustomerDto(Guid UserId,
        string UserName,
        string Email,
        string FirstName,
        string LastName,
        DateTime BirthDate);

    public record CreateNewCustomerCommand(Guid UserId,
        string UserName,
        string Email,
        string FirstName,
        string LastName,
        DateTime BirthDate) : IRequest;

    public class CreateNewCustomerHandler : IRequestHandler<CreateNewCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateNewCustomerHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateNewCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = Customer.CreateCustomer(request.UserId,
                request.FirstName,
                request.LastName,
                request.Email,
                request.UserName,
                request.BirthDate);

            _customerRepository.Insert(customer);

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }

    public class CreateNewCustomerValidator : AbstractValidator<CreateNewCustomerCommand>
    {
        public CreateNewCustomerValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("ID do usuário inválido.");

            RuleFor(x => x.UserName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100)
                .WithMessage("Nome de usuário inválido");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100)
                .WithMessage("Nome inválido");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100)
                .WithMessage("Sobrenome inválido");

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .WithMessage("Data de nascimento inválida");

            RuleFor(x => x.Email)
                .MinimumLength(3)
                .MaximumLength(256)
                .EmailAddress()
                .WithMessage("Email inválido");
        }
    }
}