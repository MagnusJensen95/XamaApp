using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RESTXama.Models;
using Newtonsoft.Json;
using RestSharp;


namespace DTUProjectApp.Toolbox
{
    class RestUpdater
    {

        public string UpdateUser(int id, Users user, RestClient client)
        {
            var request = new RestRequest("api/Users/" + id, Method.PUT);

            var toAdd = JsonConvert.SerializeObject(user);


            request.AddParameter("application/json; charset=utf-8", toAdd, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            var content = response.StatusCode;
            return content.ToString();
        }
    }
}