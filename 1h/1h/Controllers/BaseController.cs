using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace _1h

{
    public class BaseController : Controller
    {
        //
        // GET: /Base/

        protected internal static ContentResult LargeJson(object largeData)
        {
            var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue };
            var result = new ContentResult
            {
                Content = serializer.Serialize(largeData),
                ContentType = "application/json"
            };
            return result;
        }

    }
}
