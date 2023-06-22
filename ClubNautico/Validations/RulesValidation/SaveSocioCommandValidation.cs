using ClubNautico.Business.SociosBusiness.Commands;
using FluentValidation;


namespace ClubNautico.Validations.RulesValidation
{
    public class SaveSocioCommandValidation : AbstractValidator<SaveSocioCommand>
    {

        public SaveSocioCommandValidation()
        {
            RuleFor(s => s.Nombre).NotEmpty();
            RuleFor(s => s.Apellido).NotEmpty();
            RuleFor(s => s.Telefono).NotEmpty();


        }



    }
}
