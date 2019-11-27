using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DAL.Enums;
using DAL.Exceptions;
using DAL.Models;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;
using Services.Extensions;

namespace Services.Implementations
{
    public class WorkLogService : EntityService<WorkLog>, IWorkLogService
    {
        #region C

        public BaseResponse<WorkLogOutputDto> Create(WorkLogInputDto workLogInputDto)
        {
            var entity = Create(Mapper.Map<WorkLog>(workLogInputDto), out var isSaved);
            if (!isSaved)
            {
                throw new BadRequestException($"Could not log work for task: {workLogInputDto.TaskId}");
            }

            return new SuccessResponse<WorkLogOutputDto>(Mapper.Map<WorkLogOutputDto>(entity));
        }

        #endregion

        #region R

        public BaseResponse<IEnumerable<WorkLogOutputDto>> Where(IDictionary<string, string> @params)
        {
            var workLogs =  Where(@params.ToObject<WorkLogQuery>());
            return new SuccessResponse<IEnumerable<WorkLogOutputDto>>(workLogs.Select(x => Mapper.Map<WorkLogOutputDto>(x)));
        }

        public IQueryable<WorkLog> Where(WorkLogQuery queries)
        {
            if (!string.IsNullOrEmpty(queries.UserId))
            {
                var userId = Guid.Parse(queries.UserId);
                return Where(x => x.EntityStatus == EntityStatus.Activated && x.UserId == userId);
            }

            return Where(x => x.EntityStatus == EntityStatus.Activated);
        }

        #endregion

        #region U

        public BaseResponse<WorkLogOutputDto> Update(Guid id, WorkLogInputDto workLogInputDto)
        {
            var workLog = First(x => x.EntityStatus == EntityStatus.Activated && x.Id == id);
            workLog.Amount = workLogInputDto.Amount;
            workLog.DateLog = workLogInputDto.DateLog;
            workLog.Description = workLogInputDto.Description;

            var isSaved = Update(workLog);
            if (!isSaved)
            {
                throw new BadRequestException($"Could not update work log for task: {workLogInputDto.TaskId}");
            }

            return new SuccessResponse<WorkLogOutputDto>(Mapper.Map<WorkLogOutputDto>(workLog));
        }

        #endregion

        #region D

        public BaseResponse<WorkLogOutputDto> Delete(Guid id)
        {
            var workLog = First(x => x.EntityStatus == EntityStatus.Activated && x.Id == id);
            var isSaved = Delete(workLog);
            if (!isSaved)
            {
                throw new BadRequestException($"Could not delete work log id: {id}");
            }

            return new SuccessResponse<WorkLogOutputDto>(Mapper.Map<WorkLogOutputDto>(workLog));
        }

        #endregion
    }
}