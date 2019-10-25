using DAL.Models;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace Services.Abstractions
{
    public interface IBoardUserService : IEntityService<BoardUser>
    {
        BaseResponse<bool> Create(BoardUserInputDto boardUserInputDto);
    }
}