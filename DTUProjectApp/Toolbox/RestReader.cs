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
using System.Threading.Tasks;

namespace DTUProjectApp.Toolbox
{
    class RestReader
    {

        


        public async Task<Users[]> GetUsers(RestClient client)
        {

            var request = new RestRequest("api/Users", Method.GET);


            IRestResponse response = await Task.Run(() => client.Execute(request));
            var content = response.Content;
            Users[] user = JsonConvert.DeserializeObject<Users[]>(content);
            
            return user;
        }


        public async Task<Prices[]> GetPrices(RestClient client, int userID)
        {

            var request = new RestRequest("api/Prices/" + userID, Method.GET);


            IRestResponse response = await Task.Run(() => client.Execute(request));
            var content = response.Content;
            Prices[] prices = JsonConvert.DeserializeObject<Prices[]>(content);

            return prices;



        }

        public async Task<Prices[]> GetPrices(RestClient client)
        {

            var request = new RestRequest("api/Prices", Method.GET);


            IRestResponse response = await Task.Run(() => client.Execute(request));
            var content = response.Content;
            Prices[] prices = JsonConvert.DeserializeObject<Prices[]>(content);

            return prices;



        }


        public Ingredients[] GetIngredients(RestClient client, int productID)
        {

            var request = new RestRequest("api/Ingredients", Method.GET);


            IRestResponse response = client.Execute(request);
            var content = response.Content;
            Ingredients[] ingredients = JsonConvert.DeserializeObject<Ingredients[]>(content);

            return ingredients;
        }

        public RESTXama.Models.Gallery[] GetGallery(RestClient client, int userID)
        {

            var request = new RestRequest("api/Galleries", Method.GET);


            IRestResponse response = client.Execute(request);
            var content = response.Content;
            RESTXama.Models.Gallery[] galleries = JsonConvert.DeserializeObject<RESTXama.Models.Gallery[]>(content);

            return galleries;
        }


        public Userinfo[] GetUserInfo(RestClient client, int userID)
        {

            var request = new RestRequest("api/userinfoes", Method.GET);


            IRestResponse response = client.Execute(request);
            var content = response.Content;
            Userinfo[] userInfo = JsonConvert.DeserializeObject<Userinfo[]>(content);

            return userInfo;
        }
    }
}