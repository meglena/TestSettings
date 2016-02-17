using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestSettings.Models;

namespace TestSettings.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            var model = new PassedString();
            
            using (var conn = new SqlConnection(Properties.Settings.Default.DbConnectionString))
            {
                var command = new SqlCommand();
                conn.Open();
                command.Connection = conn;
                command.CommandText = "select top 1 * from Customer";
                command.CommandType = System.Data.CommandType.Text;
                var reader = command.ExecuteReader();

                if(reader.Read())
                {
                    model.text = reader.GetString(reader.GetOrdinal("Email"));
                }

                
                conn.Close();
            }
           
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
