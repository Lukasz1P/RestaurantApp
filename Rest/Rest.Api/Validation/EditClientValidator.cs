using FluentValidation;
using Rest.Api.BindingModels;

namespace Rest.Api.Validation
{
    public class EditClientValidator : AbstractValidator<EditClient> {
        public EditClientValidator() {
            RuleFor(x => x.ClientName);
            RuleFor(x => x.ClientSurName);
            RuleFor(x => x.ClientEmail);
            RuleFor(x => x.ClientPhone);
        }
    }
}