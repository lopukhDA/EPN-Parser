using EPN_Parser.EpnApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EPN_Parser.EpnApi
{
    public class Parser
    {
        private readonly string _url = "http://api.epn.bz/json";

        public List<Offer> GetTopProduct()
        {
            RequestEpn top = new RequestEpn()
            {
                Requests = new Requests()
                {
                    Request = new Request()
                    {
                        ActionRequest = ActionRequest.top_monthly,
                        Lang = Lang.ru,
                    }
                }
            };
            var data = top.ToJson();

            string response;
            using (var webClient = new WebClient())
            {

                response = webClient.UploadString(_url, data);
            }

            var responseObj = TopProductsResponse.FromJson(response);
            var products = responseObj.Results.Request.Offers;
            return products;
        }
        
    }
}