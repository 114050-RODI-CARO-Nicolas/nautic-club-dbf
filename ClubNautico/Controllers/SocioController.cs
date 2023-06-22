using ClubNautico.Business.SociosBusiness.Commands;
using ClubNautico.Business.SociosBusiness.Queries;
using ClubNautico.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace ClubNautico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocioController : ControllerBase
    {

        private readonly IMediator _mediator;
        public SocioController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("save")]
        public async Task<Socio> SaveSocio([FromBody] SaveSocioCommand saveSocioCommand) 
        {
            return await _mediator.Send(saveSocioCommand);
        }

        [HttpGet]
        [Route("get")]
        public async Task<List<Socio>> GetAllSocios()
        {
            return await _mediator.Send(new GetAllSociosQuery());
        }


        [HttpGet]
        [Route("get_by_id/{id}")]
        public async Task<Socio> GetSocioById(int id)
        {
            return await _mediator.Send(new GetSocioByIdQuery { Id = id });
        }

        [HttpPut]
        [Route("update")]
        public async Task<Socio> UpdateSocio([FromBody] UpdateSocioCommand updateSocioCommand)
        {
            return await _mediator.Send(updateSocioCommand);
        }


        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<Socio> DeleteSocio(int id)
        {
            return await _mediator.Send(new DeleteSocioCommand { Id = id });
        }




    }











}
