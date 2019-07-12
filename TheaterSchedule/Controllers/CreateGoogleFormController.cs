using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.Interfaces;
using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using TheaterSchedule.BLL.DTOs;

namespace TheaterSchedule.Controllers
{
    #region snippet_CreateGoogleFormController

    [Route("api/[controller]")]
    [ApiController]
    public class CreateGoogleFormController : Controller
    {
        private IGetDataFromGoogleFormService getService;
        private ISendDataToGoogleFormService sendService;

        public CreateGoogleFormController(IGetDataFromGoogleFormService googleFormService, ISendDataToGoogleFormService sendFormService)
        {
            getService = googleFormService;
            sendService = sendFormService;
        }


        #region snippet_GetDataFromGoogleForm
        /// <summary>
        /// Get data from Google Form
        /// </summary>
        /// <param name="url">Information about input fields</param>
        /// <returns>google fields</returns>
        /// <response code="201">Returns a json with info about fields</response>
        /// <response code="404">If the json is null</response> 
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> GetDataFromGoogleForm([FromQuery]string url = "https://docs.google.com/forms/d/e/1FAIpQLSfwgTnNsb7SvCmrkskJZINvhuGY861iNfdbMZ_1UcNylORT6A/viewform")
        {
            try
            {
                string res = JsonConvert.SerializeObject(getService.GetDataFromServer(url));
                if (res == null)
                    return NotFound();

                return StatusCode(200, res);
            }catch(Exception e)
            {
                return BadRequest(e);
            }

        }
        [HttpPost]
        [Route("SendDataToGoogleForm")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> SendDataToGoogleForm([FromBody] PollDTO inputs)
        {
            string result = sendService.Submit(inputs.RootURL, inputs.Fields, inputs.CheckBoxes);

            if (result == null)
                    return BadRequest();

                return StatusCode(200, result);
        }
        #endregion
    }
    #endregion
}
