using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace GoogleApiTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new RestClient("https://maps.googleapis.com/");
            var request = new RestRequest("maps/api/geocode/json?address=2315+se+ankeny+st,+Portland,+Or&key=AIzaSyC8qCnR0Dt4d-noRAXpkdfR9EndOWkx0N8", Method.GET);

            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            Console.WriteLine(response.Content);
            Console.ReadLine();
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}

