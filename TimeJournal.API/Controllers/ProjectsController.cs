using Microsoft.AspNetCore.Mvc;
using TimeJournal.DataModel.Entities;
using TimeJournal.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

    // GET: api/<ProjectsController>
    [HttpGet]
    public async Task<Project> Get()
    {
        return await _projectRepository.Get(0);
    }

    // GET api/<ProjectsController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<ProjectsController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<ProjectsController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ProjectsController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
