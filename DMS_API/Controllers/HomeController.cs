﻿using DMS_API.ModelsView;
using DMS_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        #region Properteis
        private ResponseModelView Response_MV { get; set; }
        #endregion

        #region Constructor
        public HomeController()
        {
        }
        #endregion

        #region Actions

        [AllowAnonymous]
        [HttpGet]
        [Route("GetHomeData")]
        public async Task<IActionResult> GetHomeData([FromHeader] RequestHeaderModelView RequestHeader)
        {
            Response_MV = await HelpService.GetHomeData(RequestHeader);
            return Response_MV.Success == true ? Ok(Response_MV) : StatusCode((int)Response_MV.Data, Response_MV);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GeneralSearchByTitle/{title}")]
        public async Task<IActionResult> GeneralSearchByTitle([FromRoute] string title, [FromHeader] RequestHeaderModelView RequestHeader)
        {
            Response_MV = await HelpService.GeneralSearchByTitle(title, RequestHeader);
            return Response_MV.Success == true ? Ok(Response_MV) : StatusCode((int)Response_MV.Data, Response_MV);
        }
        #endregion
    }
}