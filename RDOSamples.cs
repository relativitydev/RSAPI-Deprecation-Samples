using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using kCura.Relativity.Client;
using kCura.Relativity.Client.DTOs;
using Relativity.Services.ServiceProxy;
namespace Refactoring_Samples
{
    class RDOSamples
    {
        public void createRDORSAPI(IRSAPIClient proxy, int workspaceID)
        {
            proxy.APIOptions.WorkspaceID = workspaceID;

            //Pass Object Type Name
            var rdo = new RDO("RDO With Link");
            //New RDO Name
            rdo.TextIdentifier = "New RDO Name";

            var rdoCreate = proxy.Repositories.RDO.Create(rdo);
        }

        public void createRdoOm(ServiceFactory proxy)
        {

        }

        public void createRDOViaOMRest()
        {
            try
            {
                HttpClient httpClient = new HttpClient
                {
                };
                // Set the required headers.
                httpClient.DefaultRequestHeaders.Add("X-CSRF-Header", string.Empty);
                httpClient.DefaultRequestHeaders.Add("Authorization", "Basic cmVsYXRpdml0eS5hZG1pbkByZWxhdGl2aXR5LmNvbTpUZXN0MTIzNCE=");
                string url = "http://172.20.7.198/Relativity.REST/api/Relativity.Objects/workspace/1017515/object/create";
                DateTime dTNow = DateTime.Now;
                string request = "{\"request\":{\"ObjectType\":{\"ArtifactTypeID\":1000044},\"FieldValues\":[{\"Field\":{\"ArtifactID\":1039581},\"Value\":\"TEST1234\"}]}}";
                StringContent requestSC = new StringContent(request);
                requestSC.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = httpClient.PostAsync(url, requestSC).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                bool success = HttpStatusCode.Created == response.StatusCode;
                if (!success)
                {
                    throw new Exception("Failed to create fact.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception($@"Failed to create fact {ex}");
            }
        }
    }
}
