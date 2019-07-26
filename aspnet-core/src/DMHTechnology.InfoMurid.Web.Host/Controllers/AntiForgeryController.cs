using Microsoft.AspNetCore.Antiforgery;
using DMHTechnology.InfoMurid.Controllers;

namespace DMHTechnology.InfoMurid.Web.Host.Controllers
{
    public class AntiForgeryController : InfoMuridControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
