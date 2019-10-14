using DAL.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Repositories.Helpers;
using Services.Abstractions;
using Services.DTOs.Output;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class FileService : IFileService
    {
        private readonly string _uploadsRootPath;

        public FileService()
        {
            _uploadsRootPath = Path.Combine(ServiceProviderHelper.Current.GetService<IHostingEnvironment>().WebRootPath, "uploads");
        }

        public async Task<BaseResponse<string>> Upload(IFormFile file, string category)
        {
            if (file.Length <= 0)
            {
                throw new BadRequestException("The uploading file has no data");
            }

            var uploadDir = Path.Combine(_uploadsRootPath, category);
            Directory.CreateDirectory(uploadDir);
            var filePath = Path.Combine(uploadDir, $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}");
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return new SuccessResponse<string>($"{category}/{Path.GetFileName(filePath)}");

        }

        public async Task<FileStreamResult> Download(string fileRelativePath)
        {
            var filePath = Path.Combine(_uploadsRootPath, fileRelativePath);
            if (!File.Exists(filePath))
            {
                throw new DataNotFoundException($"{fileRelativePath} not found");
            }
                

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;

            return new FileStreamResult(memory, GetContentType(filePath)) { FileDownloadName = fileRelativePath };
        }

        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(path, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            return contentType;
        }
    }
}