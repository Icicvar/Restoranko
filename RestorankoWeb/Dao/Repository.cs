using Microsoft.ApplicationBlocks.Data;
using Newtonsoft.Json;
using RestorankoWeb.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RestorankoWeb.Dao
{
     class Repository : IRepository
    {
        private readonly HttpClient httpClient;

        public Repository()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:5034");
        }

        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;


        public bool CheckUser(User user)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(cs, "checkUser", user.Email, user.Password)) == 0;
        }

        public void CreateUser(User user)
        {
            SqlHelper.ExecuteNonQuery(cs, "createUser", user.FirstName, user.LastName, user.Email, user.Password);
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                // Slanje POST zahtjeva na API endpoint za provjeru autentičnosti
                var response = await httpClient.GetAsync($"api/Users");

                // Provjera statusnog koda odgovora
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();

                    IEnumerable<User> users = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<User>>(responseString);
                    return users;
                    //return (users != null);
                }
                else
                {
                    Console.WriteLine("Greška prilikom prijave: ");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greška prilikom prijave: " + ex.Message);
                return null;
            }
        }

        public async Task<bool> Register(User user)
        {
            try
            {
                // Slanje POST zahtjeva na API endpoint za provjeru autentičnosti
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("api/Users", user);

                // Provjera statusnog koda odgovora
                if (response.IsSuccessStatusCode)
                {
                    // Prijavljivanje uspješno
                    return true;
                }
                else
                {
                    // Prijavljivanje nije uspjelo
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Greška prilikom slanja zahtjeva ili obrade odgovora
                Console.WriteLine("Greška prilikom prijave: " + ex.Message);
                return false;
            }
        }


        public  async Task<User> Login(User user)
        {
            try
            {
                // Slanje POST zahtjeva na API endpoint za provjeru autentičnosti
                var response = await httpClient.GetAsync($"api/Users/Login/{user.Email}/{user.Password}");
              
                // Provjera statusnog koda odgovora
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    
                    User[] users = Newtonsoft.Json.JsonConvert.DeserializeObject<User[]>(responseString);
                    return users[0];
                    //return (users != null);
                }
                else
                {
                    Console.WriteLine("Greška prilikom prijave: " );
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greška prilikom prijave: " + ex.Message);
                return null;
            }
        }

    }
}