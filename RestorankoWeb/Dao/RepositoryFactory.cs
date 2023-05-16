using RestorankoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestorankoWeb.Dao
{
	public class RepositoryFactory
	{
        public static IRepository GetRepository()=> new Repository();
        
    }
}