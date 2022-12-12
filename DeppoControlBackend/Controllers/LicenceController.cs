using DeppoControlBackend.Entities.Dto;
using DeppoControlBackend.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeppoControlBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenceController : ControllerBase
    {

        [HttpPost("GetLicence")]
        public async Task<IActionResult> GetLicenceAsync(GetLicenceDto getLicenceDto)
        {
            DeppoCheck service = new DeppoCheck();
            var licence = await service.GetLicenceInfo(getLicenceDto);
            return licence.Success ? Ok(licence.Data) : BadRequest(licence);
        }

        [HttpPost("GetEncryptedLicenceKey")]
        public string GetEncryptedLicenceKey(GetProductKeyDto getKeyDto)
        {
            DeppoCheck service = new DeppoCheck();
            var productLicenceKey = service.GetEncryptedLicenceKey(getKeyDto);
            return productLicenceKey;
        }

        [HttpPost("GetEncryptedModuleLicenceKey")]
        public string GetEncryptedModuleLicenceKey(GetModuleKeyDto getModuleKeyDto)
        {
            DeppoCheck service = new DeppoCheck();
            var moduleLicenceKey = service.GetEncryptedModuleLicenceKey(getModuleKeyDto);
            return moduleLicenceKey;
        }
    }   
}
