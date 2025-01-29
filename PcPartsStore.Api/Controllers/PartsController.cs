using MediatR;
using Microsoft.AspNetCore.Mvc;
using PcPartsStore.Application.Features.PcParts.Commands.CreatePcPart;
using PcPartsStore.Application.Features.PcParts.Commands.DeletePcPart;
using PcPartsStore.Application.Features.PcParts.Commands.UpdatePcPart;
using PcPartsStore.Application.Features.PcParts.Queries.GetPartDetail;
using PcPartsStore.Application.Features.PcParts.Queries.GetPartsList;

namespace PcPartsStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PartsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllParts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PartsListVm>>> GetAllParts()
        {
            var dtos = await _mediator.Send(new GetPartsListQuery());

            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetPartById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PartDetailVm>> GetPartById(Guid id)
        {
            var getPartDetailQuery = new GetPartDetailQuery() { Id = id };

            return Ok(await _mediator.Send(getPartDetailQuery));
        }

        [HttpPost(Name = "AddPcPart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CreatePcPartCommandResponse>> AddPcPart([FromBody] CreatePcPartCommand createPcPartCommand)
        {
            var response = await _mediator.Send(createPcPartCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdatePcParts")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdatePcPartsCommand updatePcParts)
        {
            await _mediator.Send(updatePcParts);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeletePcPart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DeletePcPartCommandResponse>> Delete(Guid id)
        {
            var getPcPartQuery = new DeletePcPartCommand() { PartId = id };
            var response = await _mediator.Send(getPcPartQuery);
            return Ok(response);
        }
    }
}
