using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace MvcApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
          
            string root = Server.MapPath("~");
            string jsonObject;
            string fldr = root + "\\App_Data\\StateTest";

            List<Models.Fruit> fruitList = new List<Models.Fruit>();

            //search through all files in folder and suber folder with .txt extension and deseralize from JSON format
            foreach (string file in Directory.EnumerateFiles(fldr, "*.txt", SearchOption.AllDirectories))
            {
                using (StreamReader strReader = new StreamReader(file))
                {
                    while ((jsonObject = strReader.ReadLine()) != null)
                    {
                        Models.Fruit deserializedFruit = JsonConvert.DeserializeObject<Models.Fruit>(jsonObject);
                        fruitList.Add(deserializedFruit);
                    }//end while
                }//end using    
            }//end foreach

            return View(fruitList);
        }//end method


        public ActionResult About()
        {
            return View();
        }
    }
}
