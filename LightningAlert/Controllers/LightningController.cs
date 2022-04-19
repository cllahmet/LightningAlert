using LightningAlert.Model;
using LightningAlert.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LightningAlert.Controllers
{
    public class LightningController : Controller
    {
        ILogger _logger;
        ILightningService _lightningService;
        public LightningController(ILogger<LightningController> logger, ILightningService lightningService)
        {
            _logger = logger;
            _lightningService = lightningService;
        }

        [Route("LithningStrike"), AcceptVerbs("POST"), HttpPost]
        public async Task<object> LightningStrikeAsync([FromBody] LightningStrike request)
        {
            try
            {
                _lightningService.ProcessLightningStrike(request);
                return Ok("Lightning Strike success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("Test"), AcceptVerbs("Get"), HttpGet]
        public async Task<object> Test()
        {

            string fileName = @"lightning.json";

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var lightningStrike = JsonConvert.DeserializeObject<LightningStrike>(line);
                    await LightningStrikeAsync(lightningStrike);
                }
            }
            return Ok();

        }
    }
}
