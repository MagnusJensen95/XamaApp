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
    class RestInserter
    {


        public string InsertUser(Users user, RestClient client)
        {
            var request = new RestRequest("api/Users", Method.POST);

            var toAdd = JsonConvert.SerializeObject(user);


            request.AddParameter("application/json; charset=utf-8", toAdd, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            var content = response.StatusCode;
            return content.ToString();
        }

        public string InsertPrice(Prices price, RestClient client, int userID)
        {
            var request = new RestRequest("api/Prices", Method.POST);

            var toAdd = JsonConvert.SerializeObject(price);


            request.AddParameter("application/json; charset=utf-8", toAdd, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            var content = response.StatusCode;
            return content.ToString();
        }

        public string InsertGallery(RESTXama.Models.Gallery gallery, RestClient client, int userID)
        {
            var request = new RestRequest("api/Galleries", Method.POST);

            var toAdd = JsonConvert.SerializeObject(gallery);


            request.AddParameter("application/json; charset=utf-8", toAdd, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            var content = response.StatusCode;
            return content.ToString();
        }

        public string InsertUserInfo(Userinfo userinfo, RestClient client, int userID)
        {
            var request = new RestRequest("api/userinfoes", Method.POST);

            var toAdd = JsonConvert.SerializeObject(userinfo);


            request.AddParameter("application/json; charset=utf-8", toAdd, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            var content = response.StatusCode;
            return content.ToString();
        }

        public string InsertIngredient(Ingredients ingredient, RestClient client, int productID)
        {
            var request = new RestRequest("api/ingredients", Method.POST);

            var toAdd = JsonConvert.SerializeObject(ingredient);


            request.AddParameter("application/json; charset=utf-8", toAdd, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            var content = response.StatusCode;
            return content.ToString();
        }


    }

}