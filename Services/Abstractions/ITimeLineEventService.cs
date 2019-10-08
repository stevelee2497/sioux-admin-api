using System;
using System.Collections.Generic;
using DAL.Models;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace Services.Abstractions
{
    public interface ITimeLineEventService : IEntityService<TimeLineEvent>
    {
        BaseResponse<TimeLineEventOutputDto> Create(TimeLineEventInputDto entity);
        BaseResponse<IEnumerable<TimeLineEventOutputDto>> CreateMany(List<TimeLineEventInputDto> objects);
        BaseResponse<TimeLineEventOutputDto> Get(Guid id);
        BaseResponse<IEnumerable<TimeLineEventOutputDto>> Where(IDictionary<string, string> predicate);
        BaseResponse<TimeLineEventOutputDto> Update(Guid entity, TimeLineEventInputDto @event);
        BaseResponse<bool> Delete(Guid predicate);
    }
}