using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SimpleJSON;

namespace RequestTest.Pages
{

    public class AboutModel : PageModel
    {
        public string Message { get; set; }

        public string PokeResponseJSON { get; set; }
        public string ID { get; set; }
        public string NAME { get; set; }

        public void OnGet()
        {
            Message = "Your application description page.";

            String APIEndPoint = "/api/v2/pokemon/pikachu/";

            MakeAPIRequest r = new MakeAPIRequest();
            String PokeResponse = r.MakeRequest(APIEndPoint);

            PokeResponseJSON = PokeResponse;

            var N = JSON.Parse(PokeResponseJSON);

            ID = N["id"].Value;        // versionString will be a string containing "1.0"
            NAME = N["name"].Value;        // versionString will be a string containing "1.0"
        }
    }
}
