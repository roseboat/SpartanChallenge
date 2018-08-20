using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SpartanSolutionRD.Models;

namespace SpartanSolutionRD.Controllers
{
    public class HomeController : Controller
    {
        RootObject root = new RootObject();

        public IActionResult Index()
        {
            return View();
        }

        public HomeController(){
            using (StreamReader r = new StreamReader("EquipmentData.json"))
            {
                string json = r.ReadToEnd();
                this.root = JsonConvert.DeserializeObject<RootObject>(json);
            }
        }

        public RootObject GetRoot()
        {
            return root;
        }

        public List<ResultObject> getAllResults()
        {
            List<ResultObject> results = new List<ResultObject>();
            foreach (SerialisedEquipment serialEquip in root.SerialisedEquipment)
            {
                foreach (EquipmentType equipType in root.EquipmentType)
                {
                    if (serialEquip.EquipmentTypeId.Equals(equipType.Id))
                    {
                        ResultObject result = new ResultObject();
                        result.serializedExternalID = serialEquip.ExternalId;
                        result.equipmentExternalID = equipType.ExternalId;
                        result.equipmentDescription = equipType.Description;
                        results.Add(result);
                    }
                }
            }
            return results;
        }

        public List<ResultObject> getEquipmentByUnitNo(string id)
        {
            List<ResultObject> results = new List<ResultObject>();
            if (!id.Equals("") || !id.Equals(null))
            {
                foreach (SerialisedEquipment serialEquip in root.SerialisedEquipment)
                {
                    if (id.Equals(serialEquip.Id))
                    {
                        foreach (EquipmentType equipType in root.EquipmentType)
                        {
                            if (serialEquip.EquipmentTypeId.Equals(equipType.Id))
                            {
                                ResultObject result = new ResultObject();
                                result.serializedExternalID = serialEquip.ExternalId;
                                result.equipmentExternalID = equipType.ExternalId;
                                result.equipmentDescription = equipType.Description;
                                results.Add(result);
                            }
                        }
                    }
                }
            }
            return results;
        }

        public List<ResultObject> getEquipmentByItemNo(string id)
            {
                List<ResultObject> results = new List<ResultObject>();
                if (!id.Equals("") || !id.Equals(null))
                {
                foreach (EquipmentType equipType in root.EquipmentType)
                    {
                    if (id.Equals(equipType.Id))
                        {
                        foreach (SerialisedEquipment serialEquip in root.SerialisedEquipment)
                            {
                            if (equipType.Id.Equals(serialEquip.EquipmentTypeId))
                                {
                                    ResultObject result = new ResultObject();
                                    result.serializedExternalID = serialEquip.ExternalId;
                                    result.equipmentExternalID = equipType.ExternalId;
                                    result.equipmentDescription = equipType.Description;
                                    results.Add(result);
                                }
                            }
                        }
                    }
                }
                return results;
            }

        public class SerialisedEquipment
        {
            public string Id { get; set; }
            public string ExternalId { get; set; }
            public string EquipmentTypeId { get; set; }
            public int MeterReading { get; set; }
        }

        public class EquipmentType
        {
            public string Id { get; set; }
            public string ExternalId { get; set; }
            public string Description { get; set; }
        }

        public class RootObject
        {
            public List<SerialisedEquipment> SerialisedEquipment { get; set; }
            public List<EquipmentType> EquipmentType { get; set; }
        }
    }
}