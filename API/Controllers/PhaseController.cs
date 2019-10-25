using System;
using System.Collections.Generic;
using DAL.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace API.Controllers
{
    [Route("api/phases")]
    public class PhaseController : ControllerBase
    {
        private readonly IPhaseService _phaseService;

        public PhaseController(IPhaseService phaseService)
        {
            _phaseService = phaseService;
        }

        [HttpPost]
        [Authorize]
        [Produces(AppConstant.ContentType)]
        public BaseResponse<PhaseOutputDto> Create([FromBody] PhaseInputDto phaseInputDto)
        {
            return _phaseService.Create(phaseInputDto);
        }

        [HttpGet]
        [Produces(AppConstant.ContentType)]
        public BaseResponse<IEnumerable<PhaseOutputDto>> Get([FromHeader] IDictionary<string, string> @params)
        {
            return _phaseService.Get(@params);
        }

        [HttpGet("{id}")]
        [Authorize]
        [Produces(AppConstant.ContentType)]
        public BaseResponse<PhaseOutputDto> Get(Guid id)
        {
            return _phaseService.Get(id);
        }

        [HttpPut("{id}")]
        [Authorize]
        [Produces(AppConstant.ContentType)]
        public BaseResponse<PhaseOutputDto> Update([FromBody] PhaseInputDto phaseInputDto)
        {
            return _phaseService.Update(phaseInputDto);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [Produces(AppConstant.ContentType)]
        public BaseResponse<bool> Delete(Guid id)
        {
            return _phaseService.Delete(id);
        }
    }
}