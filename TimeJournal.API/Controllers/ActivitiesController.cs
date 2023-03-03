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
        var activitiesDto = activities.Select(x => new ActivityDto(x.Id, x.ProjectId, x.Name));

        return Ok(activities);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ActivityDto>> Get(int id)
    {
        var activity = await _activityRepository.Get(id);

        return Ok(new ActivityDto(activity.Id, activity.ProjectId, activity.Name));
    }

    [HttpPost]
    public async Task<ActionResult<ActivityDto>> Post([FromBody] CreateActivityDto activityDto)
    {
        var newActivity = new Activity
        {
            ProjectId = activityDto.ProjectId,
            Name = activityDto.Name
        };

        await _activityRepository.Add(newActivity);
        var routeValues = new { newActivity.Id };

        return CreatedAtAction(nameof(Get), routeValues, new ActivityDto(newActivity.Id, newActivity.ProjectId, newActivity.Name));
    }
}