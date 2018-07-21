using BuildingBlocks.Models;
using BuildingBlocks.Service.Crm;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BuildingBlocks.Controllers
{
    public class PersonController : ApiController
    {
        //http://localhost:2568/Person/Detail
        [Route("Person/Detail")]
        [HttpGet]
        public string personDetail()
        {
            //string jsonString = @"{'status':500}";
            try
            {
                PhoneHandler phoneHandler = new PhoneHandler();
                Phone phone = phoneHandler.TestPhone();
                ResultModel resultModel = new ResultModel();
                resultModel.Message = phone;
                var s = JsonConvert.SerializeObject(resultModel);
                return s;
            }
            catch (Exception ex)
            {
                ResultModel resultModel = new ResultModel();
                resultModel.IsSucess = false;
                resultModel.Message = ex;
                var s = JsonConvert.SerializeObject(resultModel);
                return s;
            }
            

            //return jsonString;
        }
    }
}

