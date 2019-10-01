using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace API.Controllers
{
    [Route("api/timeLineEvents")]
    public class TimeLineEventController : Controller
    {
        private readonly ITimeLineEventService _timeLineEventService;

        public TimeLineEventController(ITimeLineEventService timeLineEventService)
        {
            _timeLineEventService = timeLineEventService;
        }

        [HttpPost]
        [Authorize]
        [Produces("application/json")]
        public BaseResponse<TimeLineEventOutputDto> Create([FromBody] TimeLineEventInputDto @event)
        {
            return _timeLineEventService.Create(@event);
        }

        [HttpPost("many")]
        [Authorize]
        [Produces("application/json")]
        public BaseResponse<IEnumerable<TimeLineEventOutputDto>> CreateMany([FromBody] List<TimeLineEventInputDto> events)
        {
            return _timeLineEventService.CreateMany(events);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public BaseResponse<TimeLineEventOutputDto> Get(Guid id)
        {
            return _timeLineEventService.Get(id);
        }

        [HttpGet]
        [Produces("application/json")]
        public BaseResponse<IEnumerable<TimeLineEventOutputDto>> Where([FromHeader] IDictionary<string, string> @params)
        {
            return _timeLineEventService.Where(@params);
        }

        [HttpPut("{id}")]
        [Authorize]
        [Produces("application/json")]
        public BaseResponse<TimeLineEventOutputDto> Update(Guid id, [FromBody] TimeLineEventInputDto @event)
        {
            return _timeLineEventService.Update(id, @event);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [Produces("application/json")]
        public BaseResponse<bool> Delete(Guid id)
        {
            return _timeLineEventService.Delete(id);
        }
    }
}