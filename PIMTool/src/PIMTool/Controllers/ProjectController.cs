using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PIMTool.Core.Domain.Entities;
using PIMTool.Core.Interfaces.Services;
using PIMTool.Dtos;
using System.ComponentModel.DataAnnotations;

namespace PIMTool.Controllers
{
    [ApiController]
    [Route("projects")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService,
            IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> Get([FromRoute][Required] int id)
        {
            var entity = await _projectService.GetAsync(id);
            return Ok(_mapper.Map<ProjectDto>(entity));
        }


        [HttpPost]
        [Route("Create-Project")]
        public async Task<ActionResult<ProjectDto>> Post([FromBody] ProjectDto projectDto)
        {
            var entity = _mapper.Map<Project>(projectDto);
            await _projectService.AddAsync(entity);
            var createdProjectDto = _mapper.Map<ProjectDto>(entity);
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, createdProjectDto);
        }

        [HttpDelete]
        [Route("Delete-Project")]
        public async Task<ActionResult> Delete([FromBody] int id)
        {
            await _projectService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet]
        [Route("Get-All-Projects")]
        public async Task<IEnumerable<Project>> Get()
        {

            var entities = _mapper.Map<IEnumerable<Project>>(await _projectService.Get());

            return _mapper.Map<IEnumerable<Project>>(entities);

        }





    }
}