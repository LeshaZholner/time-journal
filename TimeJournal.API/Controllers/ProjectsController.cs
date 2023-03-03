using Microsoft.AspNetCore.Mvc;
using TimeJournal.DataModel.Entities;
using TimeJournal.Repositories;

namespace TimeJournal.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController : ControllerBase
{
    private readonly IProjectRepository _projectRepository;
    public ProjectsController(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public sealed record ProjectDto(int Id, string Name);
    public sealed record CreateProjectDto(string Name);

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProjectDto>>> GetAll()
    {
        var projects = await _projectRepository.GetAll();
        var projectsDto = projects.Select(x => new ProjectDto(x.Id, x.Name));

        return Ok(projectsDto);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProjectDto>> Get(int id)
    {
        var project = await _projectRepository.Get(id);
        var projectDto = new ProjectDto(project.Id, project.Name);

        return Ok(projectDto);
    }

    [HttpPost]
    public async Task<ActionResult<ProjectDto>> Post([FromBody] CreateProjectDto project)
    {
        var newProject = new Project
        {
            Name = project.Name
        };
        await _projectRepository.Add(newProject);
        var routeValues = new { newProject.Id };

        return CreatedAtAction(nameof(Get), routeValues, new ProjectDto(newProject.Id, newProject.Name));
    }
}
