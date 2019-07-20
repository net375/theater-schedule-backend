using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.Interfaces;
using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using TheaterSchedule.BLL.DTOs;
using TheaterSchedule.Infrastructure;
using System.Net;

namespace TheaterSchedule.Controllers
{
    #region snippet_CreateGoogleFormController

    [Route("api/[controller]")]
    [ApiController]
    public class CreateGoogleFormController : Controller
    {
        private IGetDataFromGoogleFormService getService;
        private ISendDataToGoogleFormService sendService;
        private IFormService getUrlService;

        public CreateGoogleFormController(IFormService getUrlService, IGetDataFromGoogleFormService googleFormService, ISendDataToGoogleFormService sendFormService)
        {
            getService = googleFormService;
            sendService = sendFormService;
            this.getUrlService = getUrlService;
        }


        #region snippet_GetDataFromGoogleForm
        /// <summary>
        /// Get data from Google Form
        /// </summary>
        /// <returns>google fields</returns>
        /// <response code="201">Returns a json with info about fields</response>
        /// <response code="404">If the json is null</response> 
        [HttpGet]
        [Produces("application/json")]
        [Route("GetDataFromGoogleForm")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<string> GetDataFromGoogleForm()
        {
            string url = getUrlService.GetUrl().Url;
            string res = JsonConvert.SerializeObject(getService.GetDataFromServer(url));
            if (res == null)
                throw new HttpStatusCodeException(
                        HttpStatusCode.NotFound, $"Unable to get the form");

            return StatusCode(201, res);
        }
        [HttpPost]
        [Route("SendDataToGoogleForm")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> SendDataToGoogleForm([FromBody] PollDTO inputs)
        {
            string url = getUrlService.GetUrl().Url;

            string result = sendService.Submit(url, inputs.Fields, inputs.CheckBoxes);

            if (result == null)
                return BadRequest();

            return StatusCode(200, result);
        }
        #endregion
    }
    #endregion
}