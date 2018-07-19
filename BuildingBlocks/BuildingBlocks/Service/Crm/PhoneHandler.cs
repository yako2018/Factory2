using BuildingBlocks.Service.Interface;
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
            Guid toGuid = Guid.Parse(id);
            Entity PhoneEntity = _clientService.Retrieve("phoneentityname", toGuid, new ColumnSet(true));
            //some field (not always all)
            //Entity ProductOrderItemEntity2 = _clientService.Retrieve("entityname", toGuid, new ColumnSet(new string[] { "name", "number" }));
            //todo
            ICrmPhone phone = new Phone();
            phone.name = "";
            phone.number = "";
            phone.phoneid = id;

            _clientService.Create(PhoneEntity);
            return "success";
        }


    }
}