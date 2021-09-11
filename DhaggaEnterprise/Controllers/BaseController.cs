using Dhagaa.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace DhaggaEnterprise.Controllers
{
    public class BaseController : ApiController
    {
        public ClientEntity Client { get; set; }

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            Client = new ClientEntity();
            base.Initialize(controllerContext);
        }
    }
}