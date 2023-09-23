using HR.Management.Application.Features.LeaveAllocation.Command.CreateLeaveAllocation;
using HR.Management.Application.Features.LeaveAllocation.Command.DeleteLeaveAllocation;
using HR.Management.Application.Features.LeaveAllocation.Command.UpdateLeaveAllocation;
using HR.Management.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations;
using HR.Management.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeaveAllocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveAlloctionController>
        [HttpGet]
        public async Task<List<LeaveAllocationDto>> Get()
        {
            var leaveAllocations = await _mediator.Send(new GetLeaveAllocationsQuery());
            return leaveAllocations;
        }

        // GET api/<LeaveAlloctionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
        {
            var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailQuery(id));
            return Ok(leaveAllocation);
        }

        // POST api/<LeaveAlloctionController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post([FromBody] CreateLeaveAllocationCommand leaveAllocation)
        {
            var response = await _mediator.Send(leaveAllocation);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<LeaveAlloctionController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveAllocationCommand leaveAllocation)
        {
            await _mediator.Send(leaveAllocation);
            return NoContent();
        }

        // DELETE api/<LeaveAlloctionController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveAllocationCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}