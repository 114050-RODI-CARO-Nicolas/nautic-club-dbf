using ClubNautico.Business.SociosBusiness.Commands;
using FluentValidation;

namespace ClubNautico.Validations.RulesValidation
{
    public class DeleteSocioCommandValidation : AbstractValidator<DeleteSocioCommand>
    {
        public DeleteSocioCommandValidation()
        {
            RuleFor(s => s.Id).NotEmpty();
        }

    }
}
