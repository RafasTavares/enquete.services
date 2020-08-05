using Enquete.Domain.Commands.OptionCommand.Commands;
using Enquete.Domain.Commands.PollCommand.Commands;
using Enquete.Domain.Queries.PollQueries.Models;
using Enquete.Domain.Queries.PollQueries.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Enquete.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollController : ControllerBase
    {

        private readonly IMediator mediator;

        public PollController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<PoolQueryModel> Get(int id)
        {
            var query = new GetByIdQuery(id);

            var handle = mediator.Send(query).Result;

            if (handle.Poll_id == 0)
                return Ok(true);

            return Ok(handle);
        }

        [HttpPost]
        public ActionResult Post([FromBody] AddPollCommand command)
        {
            // Uma opção seria receber criar um request(DTO) como parametro e criar o command dentro do método

            var handle = mediator.Send(command).Result;

            if (handle is null)
                return NotFound();

            return Ok(handle);
        }

        [HttpPost]
        [Route("{id:int}/vote")]
        public ActionResult<int> PostVote(int id)
        {
            // Uma opção seria receber criar um request(DTO) como parametro e criar o command dentro do método

            var handle = mediator.Send(new AddPollToOptionCommand(id)).Result;

            if (!handle)
                return NotFound();

            return Ok(handle);
        }

        [HttpGet]
        [Route("{id:int}/stats")]
        public ActionResult<PollViewsQueryModel> GetStats(int id)
        {
            var query = new GetByIdPollStarsQuery(id, false);

            var handle = mediator.Send(query).Result;

            if (handle.Views == 0)
                return NotFound();

            return Ok(handle);
        }

    }
}