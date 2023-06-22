using ClubNautico.Data;
using ClubNautico.Models;
using ClubNautico.Validations.DBValidation;
using ClubNautico.Validations.RulesValidation;
using MediatR;


namespace ClubNautico.Business.SociosBusiness.Commands
{




    public class SaveSocioCommand : IRequest<Socio>
        {

            public string Nombre { get; set; } = null!;

            public string Apellido { get; set; } = null!;

            public string Telefono { get; set; } = null!;
        }

        public class SaveSocioHandler : IRequestHandler<SaveSocioCommand, Socio>
        {

            private readonly ApplicationContext _context;
            private readonly SaveSocioCommandValidation _requestValidation;
            private readonly ISocioValidations _socioValidations;
            public SaveSocioHandler(ApplicationContext context, SaveSocioCommandValidation requestValidation, ISocioValidations socioValidations)
            {
                _context = context;
                _requestValidation = requestValidation;
                _socioValidations = socioValidations;
            }

            public async Task<Socio> Handle(SaveSocioCommand request, CancellationToken cancellationToken)
            {
                _requestValidation.Validate(request);

                try
                {
                    Socio socio = new Socio();
                    socio.Nombre = request.Nombre;
                    socio.Apellido = request.Apellido;
                    socio.Telefono = request.Telefono;

                    await _socioValidations.ValidateExists(socio);    

                    await _context.Socios.AddAsync(socio);
                    await _context.SaveChangesAsync();

                    return socio;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    
}
