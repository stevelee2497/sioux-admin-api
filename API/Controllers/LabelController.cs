using DAL.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;
using Services.Extensions;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/labels")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        private readonly ILabelService _labelService;

        public LabelController(ILabelService labelService)
        {
            _labelService = labelService;
        }

        [HttpPost]
        [Authorize]
        [Produces(AppConstant.ContentType)]
        public BaseResponse<LabelOutputDto> Create([FromBody] LabelInputDto labelInputDto)
        {
            var userId = User.GetUserId();
            return _labelService.Create(labelInputDto, userId);
        }

        [HttpGet]
        [Authorize]
        [Produces(AppConstant.ContentType)]
        public BaseResponse<IEnumerable<LabelOutputDto>> Get([FromHeader] IDictionary<string, string> @params)
        {
            return _labelService.Get(@params);
        }

        [HttpGet("{id}")]
        [Authorize]
        [Produces(AppConstant.ContentType)]
        public BaseResponse<LabelOutputDto> Get(Guid id)
        {
            return _labelService.Get(id);
        }

        [HttpPut("{id}")]
        [Authorize]
        [Produces(AppConstant.ContentType)]
        public BaseResponse<bool> Update(Guid id, [FromBody] LabelInputDto labelInputDto)
        {
            return _labelService.Update(id, labelInputDto);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [Produces(AppConstant.ContentType)]
        public BaseResponse<bool> Delete(Guid id)
        {
            return _labelService.Delete(id);
        }
    }
}