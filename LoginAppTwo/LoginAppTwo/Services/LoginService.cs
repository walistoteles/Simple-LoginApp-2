using LoginAppTwo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoginAppTwo.Services
{
    class LoginService
    {

        public async Task<bool> Register(User user)
        {
            string r = await Xamarin.Essentials.SecureStorage.GetAsync("login/users");
            List<User> users = new List<User>();


            if (string.IsNullOrEmpty(r))
            {
                if(user != null)
                {
                    users.Add(user);

                    string response = JsonConvert.SerializeObject(users);

                    await Xamarin.Essentials.SecureStorage.SetAsync("login/users", response);

                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                users = JsonConvert.DeserializeObject<List<User>>(r);



                for (int i = 0; i < users.Count; i++)
                {
                    if (user.UserName == users[i].UserName)
                    {
                        return false;
                    }
                    else
                    {

                        users.Add(user);

                        string rs = JsonConvert.SerializeObject(users);

                        await Xamarin.Essentials.SecureStorage.SetAsync("login/users", rs);
                        return true;
                    }
                }

                return true;

            }


        }


        public async Task<bool> Login(User user)
        {
            string r = await Xamarin.Essentials.SecureStorage.GetAsync("login/users");

            if (string.IsNullOrEmpty(r))
            {

                return false;

            }
            else
            {
                List<User> users = JsonConvert.DeserializeObject<List<User>>(r);

                for (int i = 0; i < users.Count; i++)
                {
                    if(user.UserName == users[i].UserName && user.Password == users[i].Password)
                    {

                        string currentuser = JsonConvert.SerializeObject(user);

                        await Xamarin.Essentials.SecureStorage.SetAsync("current/user", currentuser);

                        return true;
                    }

                    return false;
                
                }

                return true;
            }

        }


        public async Task<bool> LoginAutomatic()
        {

            string r = await Xamarin.Essentials.SecureStorage.GetAsync("current/user");

            if (string.IsNullOrEmpty(r))
            {
                return false;
            }
            else
            {
                User newuser = JsonConvert.DeserializeObject<User>(r);

               return await Login(newuser);
            }

        }



        public async Task<bool> Logoff()
        {
            string x = await Xamarin.Essentials.SecureStorage.GetAsync("current/user");
            string y = await Xamarin.Essentials.SecureStorage.GetAsync("login/users");

            if(!string.IsNullOrEmpty(x) && !string.IsNullOrEmpty(y))
            {                


                Xamarin.Essentials.SecureStorage.Remove("current/user");
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
