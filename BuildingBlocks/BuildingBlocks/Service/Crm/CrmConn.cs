using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;

namespace BuildingBlocks.Service.Crm
{
    //crm 必備
    //NuGet封裝管理員 > 套件管理主控台 > 
    //輸入以下指令:
    //Install-Package Microsoft.CrmSdk.CoreAssemblies -Version 9.0.0.7
    //Install-Package Microsoft.CrmSdk.Deployment -Version 9.0.0.7
    //Install-Package Microsoft.CrmSdk.XrmTooling.CoreAssembly -Version 9.0.0.7
    //Install-Package Microsoft.IdentityModel.Clients.ActiveDirectory -Version 3.19.1

    public class CrmConn
    {
        IOrganizationService _clientService;

        public IOrganizationService Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CRMConn"].ConnectionString;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            CrmServiceClient conn = new Microsoft.Xrm.Tooling.Connector.CrmServiceClient(connectionString);
            _clientService = (IOrganizationService)conn.OrganizationWebProxyClient != null ? (IOrganizationService)conn.OrganizationWebProxyClient : (IOrganizationService)conn.OrganizationServiceProxy;
            return _clientService;
        }
    }
}