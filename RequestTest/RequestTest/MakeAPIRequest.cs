using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using RestSharp;


namespace RequestTest
{
    public class MakeAPIRequest
    {
        /// <summary>
        /// 
        /// http://restsharp.org
        /// http://json2csharp.com
        /// 
        /// </summary>
        /// <param name="APIEndPoint">Example: "/api/v2/pokemon/pikachu/" </param>
        /// <returns></returns>
        public String MakeRequest(String APIEndPoint)
        {
            var client = new RestClient("https://pokeapi.co");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest(APIEndPoint, Method.GET);
            //request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
            //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource

            //// easily add HTTP Headers
            //request.AddHeader("header", "value");

            //// add files to upload (works with compatible verbs)
            //request.AddFile(path);

            // execute the request
            IRestResponse response = client.Execute(request);
            String content = response.Content; // raw content as string

            //// or automatically deserialize result
            //// return content type is sniffed but can be explicitly set via RestClient.AddHandler();
            //RestResponse response2 = client.Execute(request);
            //var name = response2.Data.Name;

            //// easy async support
            //client.ExecuteAsync(request, response => {
            //    Console.WriteLine(response.Content);
            //});

            //// async with deserialization
            //var asyncHandle = client.ExecuteAsync<Person>(request, response => {
            //    Console.WriteLine(response.Data.Name);
            //});

            //// abort the request on demand
            //asyncHandle.Abort();

            return content;
        }

    }
}
