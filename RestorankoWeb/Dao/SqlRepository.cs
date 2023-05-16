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
    public class SqlRepository : IRepository
    {
        private readonly HttpClient httpClient;

        public SqlRepository()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:5034");
        }

        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public DataSet dataSet { get; set; }

        public bool CheckUser(User user)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(cs, "checkUser", user.Email, user.Password)) == 0;
        }

        public void CreateUser(User user)
        {
            SqlHelper.ExecuteNonQuery(cs, "createUser", user.FirstName, user.LastName, user.Email, user.Password);
        }

        public async Task<bool> Login(User user)
        {
            try
            {
                // Priprema podataka za prijavu
                var loginData = new { email = user.Email, password = user.Password };

                // Slanje POST zahtjeva na API endpoint za provjeru autentičnosti
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("api/Users", loginData);

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

    }
}