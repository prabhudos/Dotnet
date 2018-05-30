using System.Web.Http;
using System.Web.Http.Cors;

namespace ChatBOT.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ChatController : ApiControllerWithHub<ChatHub>
    {
        public IHttpActionResult get()
        {
            return Ok();
        }
        
        public IHttpActionResult post(string room, string name, string message)
        {
            Hub.Clients.Group(room).broadcastMessage(name, message);

            return Ok();
        }
    }
}
