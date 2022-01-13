using LoginAppTwo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoginAppTwo.Services
{
    class GetInfoService
    {


        public async Task<User> GetUser()
        {
            string r = await Xamarin.Essentials.SecureStorage.GetAsync("current/user");


            if (string.IsNullOrEmpty(r)) { return null; }


            User user = JsonConvert.DeserializeObject<User>(r);

            return user;
            

        }
    }
}
