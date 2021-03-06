﻿using BuildingBlocks.Service.Crm;
using BuildingBlocks.Models.Interface;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildingBlocks.Service.Crm
{
    public class PhoneHandler
    {
        IOrganizationService _clientService;

        public PhoneHandler() //建構子
        {
            CrmConn crmConn = new CrmConn();
            _clientService = crmConn.Connection();
        }

        public Phone TestPhone()
        {
            ICrmPhone phone = new Phone();
            phone.clf_contact = "20180720";
            phone.name = "cloud";
            phone.number = "xxxx-xxxxxx";
            phone.phoneid = new Guid().ToString();
            return (Phone)phone;
        }

        public void Exec()
        {
            DoLogic();
        }

        public void DoLogic()
        {
            // do something...
        }

        public Phone GetData(string id)
        {
            Guid toGuid = Guid.Parse(id);
            Entity PhoneEntity = _clientService.Retrieve("phoneentityname", toGuid, new ColumnSet(true));
            //some field (not always all)
            //Entity ProductOrderItemEntity2 = _clientService.Retrieve("entityname", toGuid, new ColumnSet(new string[] { "name", "number" }));
            ICrmPhone phone = new Phone();
            if (PhoneEntity.Contains("name"))
            {
                //to be confirmed
                phone.name = ((EntityReference)PhoneEntity.Attributes["name"]).Id.ToString();//PhoneEntity.Attributes["name"].ToString();
            }
            if (PhoneEntity.Contains("number"))
            {
                phone.number = PhoneEntity.Attributes["number"].ToString();
            }
            phone.phoneid = id;

            return (Phone)phone;
        }

        public string CreateOrUpdateData(string id)
        {
            ICrmPhone phone = new Phone();
            phone.name = "";
            phone.number = "";
            phone.phoneid = id;

            Guid toGuid = new Guid();
            bool isGuid = Guid.TryParse(id, out toGuid);

            if (true || phone.phoneid == id)
            {
                //Create
                Entity entity = new Entity("phone_entityname");
                entity["clf_contact"] = new EntityReference("contact", new Guid("lookupGuid")); // Suppose clf_contact is lookup field
                entity["name"] = phone.name;
                entity["number"] = phone.number;
                _clientService.Create(entity);
            }
            else
            {
                //Update
                Entity entity = _clientService.Retrieve("phone_entityname", toGuid, new ColumnSet());
                entity["clf_contact"] = new EntityReference("contact", new Guid("lookupGuid")); // Suppose clf_contact is lookup field
                entity["name"] = phone.name;
                entity["number"] = phone.number;
                entity["phoneid"] = phone.phoneid;//Primary Key
                _clientService.Update(entity);
            }
            

            return "success";
        }


    }
}