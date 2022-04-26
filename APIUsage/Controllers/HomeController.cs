using APIUsage.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace APIUsage.Controllers
{
    public class HomeController : Controller
    {
        //some data
        private readonly List<Account> _dataList;
        private readonly Random _random;


        public HomeController()
        {
            //get your (random) data at controller initializing
            _dataList = SampleData.GetDataList();
            _random = new Random();
        }

        public ActionResult FirstTask()
        {
            return View();
        }
        #region task 1.1
        //implement the getdata method to use the data in custom.js
        public JsonResult GetData() => Json(_dataList, JsonRequestBehavior.AllowGet);
        #endregion

        #region task 2.1 + 2.2
        public async Task<ActionResult> SecondTask()
        {
            //get the current bitcoin data from https://www.coindesk.com/coindesk-api use http client 


            /* 
             * https://www.coindesk.com/coindesk-api this url response html
             * instead I found https://api.coindesk.com/v1/bpi/currentprice.json url and response json data.
             */

            BitCoin result = null;
            string url = "https://api.coindesk.com/v1/bpi/currentprice.json";

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
           
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                 result = JsonConvert.DeserializeObject<BitCoin>(await response.Content.ReadAsStringAsync());
          
            //lazyload the data in SecondTask view
            return View(result);
        }
        #endregion

        #region task 2.3
        //write a method to use the current bitcoin data in custom.js
        #endregion
    }
}