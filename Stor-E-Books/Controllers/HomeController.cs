using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Stor_E_Books.Models;
using System.Data;
using System.Diagnostics;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;

namespace Stor_E_Books.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;


        public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository)
        {
            _logger = logger;
            _homeRepository = homeRepository;
        }

        public async Task<IActionResult> Index(string sterm="", int genreId=0)
        {
            IEnumerable<Book> books = await  _homeRepository.GetBooks(sterm,genreId);
            return View(books);
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
        //comment
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

        public IActionResult Cart()
        {
            // Logic to retrieve cart items and display cart page
            return View(); // Return the cart view
        }

        [HttpGet]
        public IActionResult AddToCart()
        {
            return View();
        }
     
        [HttpPost]
        public IActionResult AddToCart(int BookID, string BookName)
        {

            CartManager.cat.Add(item: new CART_ITEM { bookID = BookID});
            

            return RedirectToAction("ShowItems");
        }

        public IActionResult Search(string searchTerm)
        {
            var matchingBooks = ItemsManager.itm.Where(book => book.BookName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            return View("ShowItems", matchingBooks);
        }
    }
}

    


