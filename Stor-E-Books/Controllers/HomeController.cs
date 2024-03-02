using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Stor_E_Books.Models;
using System.Data;
using System.Diagnostics;
using System.Xml.Linq;

namespace Stor_E_Books.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CustomerReg()
        {
            return View();
        }
        //Registering users to the Database
        [HttpPost]
        public IActionResult CustomerReg(string Name, string Surname, string Email, string Password)
        {
            SqlConnection con = new SqlConnection(@"Data Source=labVMH8OX\SQLEXPRESS;Initial Catalog=Stor-E-Books;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

            string insertQuery = "INSERT INTO CUSTOMER (name, surname, email,password) VALUES ( @Name, @Surname, @Email,@Password)";

            SqlCommand cmd = new SqlCommand(insertQuery, con);

            cmd.Parameters.AddWithValue("@name", Name);
            cmd.Parameters.AddWithValue("@surname", Surname);
            cmd.Parameters.AddWithValue("@email", Email);
            cmd.Parameters.AddWithValue("@password", Password);

            try
            {
                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine("An error occurred while opening the connection: " + ex.Message);

                throw;
            }


            return RedirectToAction("LogIn");


        }
        //Login users Method
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(string Name, string Password)
        {
            string username, pass;
            username = Name;
            pass = Password;
            SqlConnection con = new SqlConnection(@"Data Source=labVMH8OX\SQLEXPRESS;Initial Catalog=Stor-E-Books;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

            try
            {
                string Qry = "SELECT * FROM CUSTOMER WHERE name = '" + Name + "' and password = '" + Password + "'";

                SqlDataAdapter sda = new SqlDataAdapter(Qry, con);
                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {

                    username = Name;
                    pass = Password;

                    ViewBag.Message = "Login successful!";
                }
                else
                {
                    ViewBag.Message = "Invalid credentials";
                }


            }
            catch
            {

                ViewBag.Message = "An error occurred: ";
            }

            finally
            {
                con.Close();
            }
            return View();
        }


    } 
    }

    


