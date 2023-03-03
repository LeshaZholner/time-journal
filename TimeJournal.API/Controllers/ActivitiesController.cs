using Microsoft.AspNetCore.Mvc;
using TimeJournal.DataModel.Entities;
using TimeJournal.Repositories;

namespace TimeJournal.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActivitiesController : ControllerBase
{
    private readonly IActivityRepository _activityRepository;
    
    public ActivitiesController(IActivityRepository activityRepository)
    {
        _activityRepository = activityRepository;
    }

    public sealed record ActivityDto(int Id, int ProjectId, string Name);
    public sealed record CreateActivityDto(int ProjectId, string Name);

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Activity>>> GetAll()
    {
        var activities = await _activityRepository.GetAll();
        return Ok(activities);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Activity>> Get(int id)
    {
        var activity = await _activityRepository.Get(id);
        return Ok(activity);
    }

    [HttpPost]
    public async Task<ActionResult<Activity>> Post(Activity activity)
    {
        await _activityRepository.Add(activity);
        var routeValues = new { activity.Id };
        return CreatedAtRoute(routeValues, activity);
    }
}