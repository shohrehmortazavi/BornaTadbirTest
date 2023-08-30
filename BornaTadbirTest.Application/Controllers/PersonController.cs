using BornaTadbirTest.Application.Entities.Persons.Commands;
using BornaTadbirTest.Application.Entities.Persons.Dtos;
using BornaTadbirTest.Application.Entities.Persons.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BornaTadbirTest.Application.Controllers
{

    [Route("Api/V{version:apiVersion}/[controller]")]
       [ApiVersion("1")]
 public class PersonController : BaseApiController
    {
        /// <summary>
        /// Get list of persons
        /// </summary>
        /// <returns>List of person</returns>
        /// <response code="200">returns list of person</response>
        /// <response code="204">There is not any person</response>
        /// <response code="500"> Application failed to process the request</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var response = await Mediator.Send(new GetPersonsQuery());

            if (response == null || !response.Any())
                return NoContent();

            return Ok(response);
        }


        /// <summary>
        /// Creates new Person
        /// </summary>
        /// <param name="personRequestDto">Data for creating new person</param>
        /// <returns>Returns created person </returns>
        /// <response code="200">returns created person</response>
        /// <response code="500"> Application failed to process the request</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(PersonRequestDto personRequestDto)
        {
            var response = await Mediator.Send(new CreatePersonCommand(personRequestDto));
            return StatusCode(StatusCodes.Status201Created, response);
        }

    }
}
