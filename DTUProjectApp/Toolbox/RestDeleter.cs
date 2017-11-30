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
    class RestDeleter
    {
        public string DeleteUser(int id, RestClient client)
        {
            var request = new RestRequest("api/Users/" +id , Method.DELETE);
            IRestResponse response = client.Execute(request);
            var content = response.StatusCode;
            return content.ToString();
        }

        public string DeleteIngredient(int id, RestClient client)
        {
            var request = new RestRequest("api/Ingredients/" + id, Method.DELETE);
            IRestResponse response = client.Execute(request);
            var content = response.StatusCode;
            return content.ToString();
        }

        public string DeleteGallery(int id, RestClient client)
        {
            var request = new RestRequest("api/Galleries/" + id, Method.DELETE);
            IRestResponse response = client.Execute(request);
            var content = response.StatusCode;
            return content.ToString();
        }

        public string DeletePrice(int id, RestClient client)
        {
            var request = new RestRequest("api/Prices/" + id, Method.DELETE);
            IRestResponse response = client.Execute(request);
            var content = response.StatusCode;
            return content.ToString();
        }

        public string DeleteUserInfo(int id, RestClient client)
        {
            var request = new RestRequest("api/Userinfoes/" + id, Method.DELETE);
            IRestResponse response = client.Execute(request);
            var content = response.StatusCode;
            return content.ToString();
        }
    }
}