using DAL.Models;
using Services.DTOs.Input;
using Services.DTOs.Output;
using System;
using System.Collections.Generic;

namespace Services.Abstractions
{
    public interface ICommentService : IEntityService<Comment>
    {
        BaseResponse<CommentOutputDto> Create(CommentInputDto commentInputDto, Guid id);
        BaseResponse<IEnumerable<CommentOutputDto>> Get(IDictionary<string, string> @params);
        BaseResponse<CommentOutputDto> Get(Guid id);
        BaseResponse<bool> Update(Guid id, CommentInputDto commentInputDto);
        BaseResponse<bool> Delete(Guid id);
    }
}