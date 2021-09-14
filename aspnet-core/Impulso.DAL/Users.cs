using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impulso.Domain;
using Dapper;
using System.Configuration;



namespace Impulso.DAL
{
    public class Users
    {
        string _strCon;
        UserAppService _userAppService = new UserAppService();
        public Users()
        {
            _strCon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        }

     



    }
}
