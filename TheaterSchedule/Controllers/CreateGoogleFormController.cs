﻿using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.Interfaces;
using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateGoogleFormController : Controller
    {
        private IGetDataFromGoogleFormService getService;
        private ISendDataToGoogleFormService sendService;

        public CreateGoogleFormController(IGetDataFromGoogleFormService googleFormService)
        {
            getService = googleFormService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> GetDataFromGoogleForm(string url = "https://docs.google.com/forms/d/e/1FAIpQLSfwgTnNsb7SvCmrkskJZINvhuGY861iNfdbMZ_1UcNylORT6A/viewform")
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> SendDataToGoogleForm(string url = "https://docs.google.com/forms/d/e/1FAIpQLSfwgTnNsb7SvCmrkskJZINvhuGY861iNfdbMZ_1UcNylORT6A/viewform")
        {
            try
            {
                string result = await sendService.SubmitAsync(url);
                if (result == null)
                    return BadRequest();
                return StatusCode(200, result);
            }catch(Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}
