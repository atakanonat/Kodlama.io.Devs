using Application.Features.ProgrammingLanguages.Commands;
using Application.Features.ProgrammingLanguages.DTOs;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
        {
            CreatedProgrammingLanguageDTO result = await Mediator.Send(createProgrammingLanguageCommand);
            return Created("", result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand)
        {
            DeletedProgrammingLanguageDTO result = await Mediator.Send(deleteProgrammingLanguageCommand);
            return Ok(result);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, EditProgrammingLanguageCommand editProgrammingLanguageCommand)
        {
            if (Id != editProgrammingLanguageCommand.Id)
            {
                return BadRequest();
            }
            EditedProgrammingLanguageDTO result = await Mediator.Send(editProgrammingLanguageCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageQuery getListProgrammingLanguageQuery = new() { PageRequest = pageRequest };
            ProgrammingLanguageListModel result = await Mediator.Send(getListProgrammingLanguageQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageQuery getByIdProgrammingLanguageQuery)
        {
            GetByIdProgrammingLanguageDTO result = await Mediator.Send(getByIdProgrammingLanguageQuery);
            return Ok(result);
        }
    }
}