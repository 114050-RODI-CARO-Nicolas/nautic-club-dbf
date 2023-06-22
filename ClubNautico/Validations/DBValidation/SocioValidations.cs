using ClubNautico.Data;
using ClubNautico.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubNautico.Validations.DBValidation
{
    public class SocioValidation : ISocioValidations
    {
        private readonly ApplicationContext _context;
        public SocioValidation(ApplicationContext context)
        {
            _context = context;
        }





       
        public async Task ValidateExists(Socio socio)
        {
            bool existeSocios = await _context.Socios.AnyAsync(s =>
             s.Nombre == socio.Nombre);
            if(existeSocios)
            {
                throw new Exception("El socio ya existe");
            }
        }
    }
}
