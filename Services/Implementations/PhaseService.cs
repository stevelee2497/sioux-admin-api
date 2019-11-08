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
    public class PhaseService : EntityService<Phase>, IPhaseService
    {
        #region C

        public BaseResponse<PhaseOutputDto> Create(PhaseInputDto phaseInputDto)
        {
            var phase = Create(Mapper.Map<Phase>(phaseInputDto), out var isSaved);
            if (!isSaved)
            {
                throw new InternalServerErrorException($"Could not create {phaseInputDto.Name}");
            }

            return new SuccessResponse<PhaseOutputDto>(Mapper.Map<PhaseOutputDto>(phase));
        }

        #endregion

        #region R

        public BaseResponse<IEnumerable<PhaseOutputDto>> Get(IDictionary<string, string> @params)
        {
            var queries = @params.ToObject<PhaseQuery>();
            var phases = Where(queries).Select(x => Mapper.Map<PhaseOutputDto>(x));
            return new SuccessResponse<IEnumerable<PhaseOutputDto>>(phases);
        }

        public BaseResponse<PhaseOutputDto> Get(Guid id)
        {
            var phase = First(x => x.EntityStatus == EntityStatus.Activated && x.Id == id);
            return new SuccessResponse<PhaseOutputDto>(Mapper.Map<PhaseOutputDto>(phase));
        }

        private IQueryable<Phase> Where(PhaseQuery queries)
        {
            if (!string.IsNullOrEmpty(queries.BoardId))
            {
                var boardId = Guid.Parse(queries.BoardId);
                return Where(x => x.EntityStatus == EntityStatus.Activated && x.BoardId == boardId);
            }

            return Where(x => x.EntityStatus == EntityStatus.Activated);
        }

        #endregion

        #region U

        public BaseResponse<PhaseOutputDto> Update(PhaseInputDto phaseInputDto)
        {
            var phase = Mapper.Map<Phase>(phaseInputDto);
            Update(phase);
            return new SuccessResponse<PhaseOutputDto>(Mapper.Map<PhaseOutputDto>(phase));
        }

        #endregion

        #region D

        public BaseResponse<bool> Delete(Guid id)
        {
            var phase = First(x => x.EntityStatus == EntityStatus.Activated && x.Id == id);
            var isSaved = Delete(phase);
            return new SuccessResponse<bool>(isSaved);
        }

        #endregion
    }
}