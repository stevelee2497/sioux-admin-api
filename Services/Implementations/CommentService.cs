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
    public class CommentService : EntityService<Comment>, ICommentService
    {
        #region C

        public BaseResponse<CommentOutputDto> Create(CommentInputDto commentInputDto, Guid id)
        {
            var comment = Create(Mapper.Map<Comment>(commentInputDto), out var isSaved);
            if (!isSaved)
            {
                throw new InternalServerErrorException("Could not create Comment");
            }

            return new SuccessResponse<CommentOutputDto>(Mapper.Map<CommentOutputDto>(comment));
        }

        #endregion

        #region R

        public BaseResponse<CommentOutputDto> Get(Guid id)
        {
            var comment = First(x => x.Id == id && x.EntityStatus == EntityStatus.Activated);
            return new SuccessResponse<CommentOutputDto>(Mapper.Map<CommentOutputDto>(comment));
        }

        public BaseResponse<IEnumerable<CommentOutputDto>> Get(IDictionary<string, string> @params)
        {
            var comments = Where(@params.ToObject<CommentQuery>()).OrderByDescending(x => x.CreatedTime).Select(x => Mapper.Map<CommentOutputDto>(x));
            return new SuccessResponse<IEnumerable<CommentOutputDto>>(comments);
        }

        private IQueryable<Comment> Where(CommentQuery queries)
        {
            if (!string.IsNullOrEmpty(queries.TaskId))
            {
                var taskId = Guid.Parse(queries.TaskId);
                return Where(x => x.TaskId == taskId && x.EntityStatus == EntityStatus.Activated);
            }

            return Where(x => x.EntityStatus == EntityStatus.Activated);
        }

        #endregion

        #region U

        public BaseResponse<bool> Update(Guid id, CommentInputDto commentInputDto)
        {
            var comment = First(x => x.Id == id);
            comment.Content = commentInputDto.Content;

            var isSaved = Update(comment);
            if (!isSaved)
            {
                throw new InternalServerErrorException("Could not update Comment");
            }

            return new SuccessResponse<bool>(true);
        }

        #endregion

        #region D

        public BaseResponse<bool> Delete(Guid id)
        {
            var comment = First(x => x.EntityStatus == EntityStatus.Activated && x.Id == id);
            var deleted = DeletePermanent(comment);
            if (!deleted)
            {
                throw new InternalServerErrorException("Could not delete Comment");
            }

            return new SuccessResponse<bool>(true);
        }

        #endregion
    }
}