using ClubNautico.Business.SociosBusiness.Queries;
using FluentValidation;

namespace ClubNautico.Validations.RulesValidation
{

    public class GetSocioByIdQueryValidation : AbstractValidator<GetSocioByIdQuery>
    {

        public GetSocioByIdQueryValidation()
        {
            RuleFor(g => g.Id).NotEmpty();
        }
    }






}
