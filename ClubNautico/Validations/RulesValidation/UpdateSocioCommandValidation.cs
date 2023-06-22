using ClubNautico.Business.SociosBusiness.Commands;
using FluentValidation;

namespace ClubNautico.Validations.RulesValidation
{
    public class UpdateSocioCommandValidation : AbstractValidator<UpdateSocioCommand>
    {
        public UpdateSocioCommandValidation()
        {
            RuleFor(s => s.Id).NotEmpty();
            RuleFor(s => s.Nombre).NotEmpty();
            RuleFor(s => s.Apellido).NotEmpty();
            RuleFor(s => s.Telefono).NotEmpty();
        }




    }
}
