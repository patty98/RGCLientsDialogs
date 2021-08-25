using iMessengerCoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace iMessengerCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        // GET: api/<ClientsController>
        [HttpGet]
        public ActionResult<List<RGDialogsClients>> Get()
        {
           return GetRGDialogsClients();
       
        }

        // POST api/<ClientsController>
        [HttpPost]
        public ActionResult<Guid> Post(IEnumerable<Guid> IDClients)
        {
            List<Guid> IDDialogs = new List<Guid>();
            List<RGDialogsClients> rGDialogsClients = GetRGDialogsClients();
            foreach(Guid id in IDClients)
            {
                RGDialogsClients occuranceDialogClient= rGDialogsClients.Find(x => x.IDClient == id);
                if(!IDDialogs.Contains(occuranceDialogClient.IDRGDialog))
                    IDDialogs.Add(occuranceDialogClient.IDRGDialog);
                
            }
            if (IDDialogs.Count > 1)
                return Guid.Empty;
            else
                return IDDialogs.First();
                     
                      
        }
        private List<RGDialogsClients> GetRGDialogsClients()
        {
            RGDialogsClients rGDialogsClients = new RGDialogsClients();

            return rGDialogsClients.Init();
        }
    }
}
