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
    
    public sealed record WorkloadDto(int Id, int ActivityId, double Duration, DateTime Date);
    public sealed record CreateWorkloadDto(int ActivityId, double Duration, DateTime Date);

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WorkloadDto>>> GetAll()
    {
        var workloads = await _workloadRepository.GetAll();
        var workloadsDto = workloads.Select(x => new WorkloadDto(x.Id, x.ActivityId, x.Duration, x.Date));

        return Ok(workloadsDto);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<WorkloadDto>> Get(int id)
    {
        var workload = await _workloadRepository.Get(id);
        
        return Ok(new WorkloadDto(workload.Id, workload.ActivityId, workload.Duration, workload.Date));
    }

    [HttpPost]
    public async Task<ActionResult<WorkloadDto>> Post([FromBody] CreateWorkloadDto workloadDto)
    {
        var newWorkload = new Workload
        {
            ActivityId = workloadDto.ActivityId,
            Duration = workloadDto.Duration,
            Date = workloadDto.Date
        };

        await _workloadRepository.Add(newWorkload);
        var routeValues = new { newWorkload.Id };

        return CreatedAtAction(nameof(Get), routeValues, new WorkloadDto(newWorkload.Id, newWorkload.ActivityId, newWorkload.Duration, newWorkload.Date));
    }
}