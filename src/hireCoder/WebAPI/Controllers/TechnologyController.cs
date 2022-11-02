using Application.Features.Technologies.Commands;
using Application.Features.Technologies.DTOs;
using Application.Features.Technologies.Models;
using Application.Features.Technologies.Queries.GetByIdTechnology;
using Application.Features.Technologies.Queries.GetListTechnology;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListTechnologyQuery technologyQuery = new() { PageRequest = pageRequest };
            TechnologyListModel result = await Mediator.Send(technologyQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById([FromRoute] GetByIdTechnologyQuery getByIdTechnologyQuery)
        {
            GetByIdTechnologyDTO result = await Mediator.Send(getByIdTechnologyQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] CreateTechnologyCommand createTechnologyCommand)
        {
            CreatedTechnologyDTO result = await Mediator.Send(createTechnologyCommand);
            return Created("", result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] EditTechnologyCommand editTechnologyCommand)
        {
            if (id != editTechnologyCommand.Id)
            {
                return BadRequest();
            }
            EditedTechnologyDTO result = await Mediator.Send(editTechnologyCommand);
            return Ok(result);
        }
    }
}