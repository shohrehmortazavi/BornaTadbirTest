using Azure.Messaging;
using BornaTadbirTest.Application.Enities.BuyTransactions.Dtos;
using BornaTadbirTest.Application.Entities.BuyTransactions.Commands;
using BornaTadbirTest.Application.Entities.BuyTransactions.Dtos;
using BornaTadbirTest.Application.Entities.BuyTransactions.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BornaTadbirTest.Application.Controllers
{

    [Route("Api/V{version:apiVersion}")]
    [ApiVersion("1")]
    public class BuyTransactionController : BaseApiController
    {
        /// <summary>
        /// Get list of buyTransactions
        /// </summary>
        /// <returns>List of buyTransactions</returns>
        /// <response code="200">returns list of buyTransactions</response>
        /// <response code="204">There is not any buyTransaction</response>
        /// <response code="500"> Application failed to process the request</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var response = await Mediator.Send(new GetBuyTransactionsQuery(null));

            if (response == null || !response.Any())
                return NoContent();

            return Ok(response);
        }


        /// <summary>
        /// Creates new BuyTransaction
        /// </summary>
        /// <param name="buyTransactionRequestDto">Data for creating new buyTransaction</param>
        /// <returns>Returns created buyTransaction</returns>
        /// <response code="200">returns created buyTransaction</response>
        /// <response code="500"> Application failed to process the request</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(BuyTransactionRequestDto buyTransactionRequestDto)
        {
            var response = await Mediator.Send(new CreateBuyTransactionCommand(buyTransactionRequestDto));
            return StatusCode(StatusCodes.Status201Created, response);
        }








        /// <summary>
        /// Get list of buyTransactions
        /// </summary>
        /// <param name="userId">Id of specific person</param>
        /// <returns>List of buyTransactions</returns>
        /// <response code="200">returns list of buyTransactions</response>
        /// <response code="204">There is not any buyTransaction</response>
        /// <response code="500"> Application failed to process the request</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetTransactionReport/{userId:int?}")]
        public async Task<IActionResult> Get(int? userId)
        {
            var response = await Mediator.Send(new GetBuyTransactionsQuery(userId));

            if (response == null || !response.Any())
                return NoContent();

            return Ok(response);
        }


        /// <summary>
        /// Get Max Buyer
        /// </summary>
        /// <returns>Max Buyer Info</returns>
        /// <response code="200">Max Buyer Info</response>
        /// <response code="204">There is not any Buyer</response>
        /// <response code="500"> Application failed to process the request</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetMaxBuyer")]
        public async Task<IActionResult> GetMaxBuyer()
        {
            var response = await Mediator.Send(new GetMaxBuyerQuery());

            if (response == null)
                return NoContent();

            return Ok(response);
        }

        /// <summary>
        /// Get max buyer info between two dates
        /// </summary>
        /// <param name="request">include StartDate and EndDate</param>
        /// <returns></returns>

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("GetMaxBuyerInDate")]
        public async Task<IActionResult> GetMaxBuyerInDate(BuyerPersonRequestDto request)
        {
            var response = await Mediator.Send(new GetMaxBuyerInDateQuery(request));

            if (response == null)
                return NoContent();

            return Ok(response);
        }


    }
}
