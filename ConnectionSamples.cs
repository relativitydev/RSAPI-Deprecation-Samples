using kCura.Relativity.Client;
using System;
using Relativity.Services.ServiceProxy;

namespace Refactoring_Samples
{
    class ConnectionSamples
    {
        public IRSAPIClient getIRSAPIClient()
        {
            Uri ROneEndpoint = new Uri("{my_company_name}/Relativity.services");
            IRSAPIClient rsapiClient = new RSAPIClient(ROneEndpoint, new kCura.Relativity.Client.UsernamePasswordCredentials("username", "password));
            return rsapiClient;
        }

        public ServiceFactory getNewServiceFactory()
        {

            // DevVm Address
            String restServerAddress = "{my_company_name}/Relativity.Rest/Api";
            string rsapiAddress = "{my_company_name}/Relativity.Services";

            Uri keplerUri = new Uri(restServerAddress);
            Uri servicesUri = new Uri(rsapiAddress);

            ServiceFactorySettings settings = new ServiceFactorySettings(
                servicesUri, keplerUri, new Relativity.Services.ServiceProxy.UsernamePasswordCredentials("username", "password"));

            Relativity.Services.ServiceProxy.ServiceFactory _serviceFactory = new Relativity.Services.ServiceProxy.ServiceFactory(settings);

            return _serviceFactory;
        }
    }
}
