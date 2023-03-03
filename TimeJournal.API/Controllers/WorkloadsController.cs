using Microsoft.AspNetCore.Mvc;
using TimeJournal.DataModel.Entities;
using TimeJournal.Repositories;

namespace TimeJournal.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkloadsController : ControllerBase
{
    private readonly IWorkloadRepository _workloadRepository;

    public WorkloadsController(IWorkloadRepository workloadRepository)
    {
        _workloadRepository = workloadRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Workload>>> GetAll()
    {
        return Ok(await _workloadRepository.GetAll());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Workload>> Get(int id)
    {
        var workload = await _workloadRepository.Get(id);
        return Ok(workload);
    }

    [HttpPost]
    public async Task<ActionResult<Workload>> Post([FromBody] Workload workload)
    {
        await _workloadRepository.Add(workload);
        
        var routeValues = new { workload.Id };
        return CreatedAtRoute(routeValues, workload);
    }
}