using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Application;

namespace NotificationService.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdersAsync([FromQuery] GetOrdersQuery query, CancellationToken cancellationToken) 
            => Ok(await _mediator.Send(query, cancellationToken));
        
        [HttpGet("{id:long:min(1)}")]
        public async Task<IActionResult> GetOrderAsync([FromRoute] long id, CancellationToken cancellationToken)
            => Ok(await _mediator.Send(new GetOrderByIdQuery(id), cancellationToken));


        /// <remarks>
        /// Sample request:
        ///     POST api/orders
        ///     {
        ///         "ProductId": 1,
        ///         "BuyerName": "Andriy",
        ///         "BuyerEmail": "andriyzybyk@gmail.com",
        ///         "City": "Ternopil",
        ///         "Adress": "some adress"
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderCommand command, CancellationToken cancellationToken)
            => Ok(await _mediator.Send(command, cancellationToken));

        [HttpPut("{id:long:min(1)}/complete")]
        public async Task<IActionResult> DeliverOrderAsync([FromRoute] long id, CancellationToken cancellationToken)
            => Ok(await _mediator.Send(new CompleteOrderCommand(id), cancellationToken));

        [HttpPut("{id:long:min(1)}/cancell")]
        public async Task<IActionResult> CancellOrderAsync([FromRoute] long id, CancellationToken cancellationToken)
            => Ok(await _mediator.Send(new CancellOrderCommand(id), cancellationToken));
    }
}