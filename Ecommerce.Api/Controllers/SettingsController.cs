using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SettingsController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet("{setting}")]
        public IActionResult Get(string setting)
        {
            if (setting == "connectionstring")
            {
                var cs = this._configuration.GetConnectionString("MyDb");
                if (cs != null)
                {
                    return Ok(cs);
                }
                else
                    return NotFound();
            }
            else if (setting == "special")
            {
                var specialSetting = this._configuration["MySetting"];
                if (specialSetting != null)
                    return Ok(specialSetting);
                else
                    return NotFound();
            }

            return BadRequest();
        }
    }
}
