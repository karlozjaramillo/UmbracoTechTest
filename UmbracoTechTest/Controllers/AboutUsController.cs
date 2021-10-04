using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace UmbracoTechTest.Controllers
{
    public class AboutUsController : SurfaceController, IRenderMvcController
    {
        // GET: AboutUs
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Index(RenderModel model)
        {
            return View(model.Content);
        }
    }
}