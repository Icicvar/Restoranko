using RestorankoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestorankoWeb.Dao
{
    public interface IRepository
    {
        bool CheckUser(User user);
        void CreateUser(User user);
        
    }
}