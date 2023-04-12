using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Modul1.ViewModels;
using FIT_Api_Example.Modul2.Models;
using FIT_Api_Example.Modul3_SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace FIT_Api_Example.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class HubController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHubContext<PorukeHub> porukeHub;

        public HubController(ApplicationDbContext dbContext, IHubContext<PorukeHub> porukeHub)
        {
            this._dbContext = dbContext;
            this.porukeHub = porukeHub;
        }

     
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] PorukaVM x)
        {

            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult> PosaljiPoruku(string p)
        {

            
            await porukeHub.Clients.All.SendAsync("slanjePoruke2", p);

   
            return Ok();
        }


        [HttpGet]
        public ActionResult GetAll()
        {
            var poruka = _dbContext.Poruka.ToList();
            return Ok(poruka);
        }


        [HttpPost("{id}")]
        public ActionResult Delete()
        {
            return Ok();
        }
    }
}
