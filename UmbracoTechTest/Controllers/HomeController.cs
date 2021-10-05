﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace UmbracoTechTest.Controllers
{
    public class HomeController : SurfaceController, IRenderMvcController
    {
        public ActionResult Index(RenderModel model)
        {
            return View(model.Content);
        }
    }
}