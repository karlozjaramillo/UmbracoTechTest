using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace UmbracoTechTest.Controllers
{
    public class NewsController : SurfaceController, IRenderMvcController
    {
        public ActionResult Index(RenderModel model)
        {
            return View(model.Content);
        }
    }
}