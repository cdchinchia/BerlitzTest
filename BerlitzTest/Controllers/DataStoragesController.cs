using BerlitzTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BerlitzTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataStoragesController : ControllerBase
    {
        public IActionResult SelectDataStorage(int dataStorage)
        {
            HttpContext.Session.SetInt32(nameof(DataStorages),dataStorage);
            return Ok();
        }
    }
}
