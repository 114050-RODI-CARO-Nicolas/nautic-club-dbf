using ClubNautico.Data;
using ClubNautico.Models;
using ClubNautico.Validations.RulesValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClubNautico.Business.SociosBusiness.Queries
{


    public class GetSocioByIdQuery:IRequest<Socio>
        {
            public int Id { get; set; }
        }










        public class GetSocioByIdHandler : IRequestHandler<GetSocioByIdQuery, Socio>
        {

            private ApplicationContext _context;
            private readonly GetSocioByIdQueryValidation _validation;
            public GetSocioByIdHandler(ApplicationContext context)
            {
                _context = context;
            }

            public async Task<Socio> Handle(GetSocioByIdQuery request, CancellationToken cancellationToken)
            {

                _validation.Validate(request);
                try
                {
                    var socio= await _context.Socios.FirstOrDefaultAsync(s=>s.Id==request.Id);
                    if(socio!=null) 
                        return socio;
                    else
                        throw new ArgumentNullException(nameof(socio));
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

        }




















    
}
