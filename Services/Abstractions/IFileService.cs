using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Output;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IFileService
    {
        Task<BaseResponse<string>> Upload(IFormFile file, string category);
        Task<FileStreamResult> Download(string fileRelativePath);
    }
}