using AutoMapper;
using DAL.Constants;
using DAL.Exceptions;
using DAL.Models;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;
using Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Enums;

namespace Services.Implementations
{
    public class TimeLineEventService : EntityService<TimeLineEvent>, ITimeLineEventService
    {
        #region Create

        public BaseResponse<TimeLineEventOutputDto> Create(TimeLineEventInputDto entity)
        {
            var timeLineEvent = Create(Mapper.Map<TimeLineEvent>(entity), out var isSaved);
            if (!isSaved)
            {
                throw new InternalServerErrorException(string.Format(Error.CreateError, entity.UserId));
            }

            return new SuccessResponse<TimeLineEventOutputDto>(Mapper.Map<TimeLineEventOutputDto>(timeLineEvent));
        }

        #endregion

        #region Create Many

        public BaseResponse<IEnumerable<TimeLineEventOutputDto>> CreateMany(List<TimeLineEventInputDto> timeLineEvents)
        {
            var entities = CreateMany(timeLineEvents.Select(Mapper.Map<TimeLineEvent>), out var isSaved);
            if (!isSaved)
            {
                throw new InternalServerErrorException(string.Format(Error.CreateError, "TimeLineEvents"));
            }

            return new SuccessResponse<IEnumerable<TimeLineEventOutputDto>>(entities.Select(Mapper.Map<TimeLineEventOutputDto>));
        }

        #endregion

        #region Get Specific


        public BaseResponse<TimeLineEventOutputDto> Get(Guid id)
        {
            var timeLineEvent = First(x => x.EntityStatus == EntityStatus.Activated && x.Id == id);
            return new SuccessResponse<TimeLineEventOutputDto>(Mapper.Map<TimeLineEventOutputDto>(timeLineEvent));
        }

        #endregion

        #region Get Many

        public BaseResponse<IEnumerable<TimeLineEventOutputDto>> Where(IDictionary<string, string> queryObj)
        {
            var query = queryObj.ToObject<TimeLineEventQuery>();
            var timeLineEvents = Where(query).Select(x => Mapper.Map<TimeLineEventOutputDto>(x));
            return new SuccessResponse<IEnumerable<TimeLineEventOutputDto>>(timeLineEvents);
        }

        private IQueryable<TimeLineEvent> Where(TimeLineEventQuery query)
        {
            var linq = All();

            if (!string.IsNullOrEmpty(query.UserId))
            {
                var userId = Guid.Parse(query.UserId);
                linq = Where(x => x.EntityStatus == EntityStatus.Activated && x.UserId == userId);
            }

            return linq;
        }

        #endregion

        #region Update

        public BaseResponse<TimeLineEventOutputDto> Update(Guid id, TimeLineEventInputDto @event)
        {
            var timeLineEvent = First(x => x.EntityStatus == EntityStatus.Activated && x.Id == id);
            timeLineEvent.Event = @event.Event;
            var isSaved = Update(timeLineEvent);
            if (!isSaved)
            {
                throw new InternalServerErrorException(string.Format(Error.CreateError, @event.Event));
            }

            return new SuccessResponse<TimeLineEventOutputDto>(Mapper.Map<TimeLineEventOutputDto>(timeLineEvent));
        }

        #endregion

        #region Delete

        public BaseResponse<bool> Delete(Guid id)
        {
            var timeLineEvent = First(x => x.EntityStatus == EntityStatus.Activated && x.Id == id);
            var deleted = Delete(timeLineEvent);
            return new SuccessResponse<bool>(deleted);
        }

        #endregion
    }
}