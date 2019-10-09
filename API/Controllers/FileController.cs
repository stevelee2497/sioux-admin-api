using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.DTOs.Output;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/files")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        [Produces("application/json")]
        public Task<BaseResponse<string>> Upload(IFormFile file, [FromForm] string category)
        {
            return _fileService.Upload(file, category);
        }

        [HttpGet("{category}/{fileName}")]
        public Task<FileStreamResult> Download(string category, string fileName)
        {
            return _fileService.Download($"{category}/{fileName}");
        }
    }
}