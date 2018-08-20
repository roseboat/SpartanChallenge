using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpartanSolutionRD.Models;

namespace SpartanSolutionRD.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        HomeController homeController = new HomeController();

        // GET api/values
        [HttpGet]
        public IEnumerable<ResultObject> Get()
        {
            List<ResultObject> results = homeController.getAllResults();
            return results;
        }

        //  GET api/values/5
        [HttpGet("{type}/{id}")]
        public IEnumerable<ResultObject> Get(string type, string id)
        {
            List<ResultObject> results = new List<ResultObject>();
            if (type.Equals("unit"))
            {
                results = homeController.getEquipmentByUnitNo(id);
            }
            else if (type.Equals("item"))
            {
                results = homeController.getEquipmentByItemNo(id);
            }

            return results;
        }

    }
}
