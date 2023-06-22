using ClubNautico.Models;

namespace ClubNautico.Validations.DBValidation
{
    public interface ISocioValidations
    {
        Task ValidateExists(Socio socio);
    }
}
