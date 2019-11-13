using AutoMapper;
using DAL.Enums;
using DAL.Exceptions;
using DAL.Models;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;
using Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementations
{
    public class LabelService : EntityService<Label>, ILabelService
    {
        #region C

        public BaseResponse<LabelOutputDto> Create(LabelInputDto labelInputDto, Guid id)
        {
            var label = Create(Mapper.Map<Label>(labelInputDto), out var isSaved);
            if (!isSaved)
            {
                throw new InternalServerErrorException("Could not create label");
            }

            return new SuccessResponse<LabelOutputDto>(Mapper.Map<LabelOutputDto>(label));
        }

        #endregion

        #region R

        public BaseResponse<LabelOutputDto> Get(Guid id)
        {
            var label = First(x => x.Id == id && x.EntityStatus == EntityStatus.Activated);
            return new SuccessResponse<LabelOutputDto>(Mapper.Map<LabelOutputDto>(label));
        }

        public BaseResponse<IEnumerable<LabelOutputDto>> Get(IDictionary<string, string> @params)
        {
            var labels = Where(@params.ToObject<LabelQuery>()).Select(x => Mapper.Map<LabelOutputDto>(x));
            return new SuccessResponse<IEnumerable<LabelOutputDto>>(labels);
        }

        private IQueryable<Label> Where(LabelQuery queries)
        {
            if (!string.IsNullOrEmpty(queries.BoardId))
            {
                var boardId = Guid.Parse(queries.BoardId);
                return Where(x => x.BoardId == boardId && x.EntityStatus == EntityStatus.Activated);
            }

            return Where(x => x.EntityStatus == EntityStatus.Activated);
        }

        #endregion

        #region U

        public BaseResponse<bool> Update(Guid id, LabelInputDto labelInputDto)
        {
            var label = Mapper.Map<Label>(labelInputDto);
            label.Id = id;

            var isSaved = Update(label);
            if (!isSaved)
            {
                throw new InternalServerErrorException("Could not create label");
            }

            return new SuccessResponse<bool>(true);
        }

        #endregion

        #region D

        public BaseResponse<bool> Delete(Guid id)
        {
            var label = First(x => x.EntityStatus == EntityStatus.Activated && x.Id == id);
            var deleted = DeletePermanent(label);
            if (!deleted)
            {
                throw new InternalServerErrorException("Could not create label");
            }

            return new SuccessResponse<bool>(true);
        }

        #endregion
    }
}