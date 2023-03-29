using FluentValidation;
using Rest.Api.BindingModels;

namespace Rest.Api.Validation
{
    public class CreateClientValidator: AbstractValidator<CreateClient>
    {
        public CreateClientValidator() {
            RuleFor(x => x.ClientName).NotEmpty();
            RuleFor(x => x.ClientSurName).NotNull();
            RuleFor(x => x.ClientEmail).NotNull();
            RuleFor(x => x.ClientPhone).NotNull();
        }
    }

}