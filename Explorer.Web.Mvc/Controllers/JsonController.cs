﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Explorer.Web.Mvc.Controllers
{
    public class JsonController : Controller
    {
        //
        // GET: /Json/

        protected new ActionResult Json(object data, JsonRequestBehavior behavior = JsonRequestBehavior.DenyGet)
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            if (Request.RequestType == WebRequestMethods.Http.Get && behavior == JsonRequestBehavior.DenyGet)
                throw new InvalidOperationException("Get is not permitted for this request");

            var jsonResult = new ContentResult
            {
                Content = JsonConvert.SerializeObject(data, jsonSerializerSettings),
                ContentType = "application/json"
            };

            return jsonResult;
        }

    }
}