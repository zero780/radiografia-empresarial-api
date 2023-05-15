using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Core.Utils
{
    public class CasUtil
    {
        public static async Task<string> ConsumeCasValidate(string baseURL, string action, string service, string ticket)
        {
            string result = "";

            // Validate service ticket (HTTP GET)
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseURL);

                // Setting content type
                //client.DefaultRequestHeaders.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Initialization.  
                HttpResponseMessage response = new HttpResponseMessage();

                // HTTP GET  
                System.Diagnostics.Debug.WriteLine($"\n** Consuming CAS Validate: {baseURL}{action}?service={service}&ticket={ticket}");
                response = await client.GetAsync($"{action}?service={service}&ticket={ticket}");

                // Verification  
                if (response.IsSuccessStatusCode)
                {
                    // Reading Response.  
                    result = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    result = BuildCasValidateResponse(false, $"CAS validation responded with {response.StatusCode} status code.");
                }
            }
            return result;
        }

        public static string BuildCasValidateResponse(bool isOk, string content)
        {
            if (isOk)
            {
                return "";
            }
            return BuildCasValidateErrorResponse(content);
        }

        public static bool CheckCasValidateFromResponse(string response)
        {
            return response.Contains("<cas:authenticationSuccess>");
        }

        public static string GetUsernameFromResponse(string response)
        {
            string[] A = response.Split(new string[] { "<cas:user>" }, StringSplitOptions.None);
            string[] B = A[1].Split(new string[] { "</cas:user>" }, StringSplitOptions.None);
            return B[0].Trim() + "@espol.edu.ec";
        }

        public static string BuildCasValidateOkResponse(string content)
        {
            return "<cas:serviceResponse xmlns:cas='http://www.yale.edu/tp/cas'>\n" +
                    "\t<cas:authenticationSuccess>\n" +
                    $"\t\t<cas:user> {content} </cas:user>\n" +
                    "\t</cas:authenticationSuccess>\n" +
                    "</cas:serviceResponse>";
        }

        public static string BuildCasValidateErrorResponse(string content)
        {
            return "<cas:serviceResponse xmlns:cas='http://www.yale.edu/tp/cas'>\n" +
                "\t<cas:authenticationFailure code=\"INTERNAL_ERROR\">\n" +
                $"\t\t {content} \n" +
                "\t</cas:authenticationFailure>\n" +
                "</cas:serviceResponse>";
        }
    }
}
