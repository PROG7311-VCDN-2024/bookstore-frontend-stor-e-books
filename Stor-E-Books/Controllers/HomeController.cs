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
        //comment
        public IActionResult CustomerReg()
        {
            return View();
        }
        //Registering users to the Database
        [HttpPost]
        public IActionResult CustomerReg(string Name, string Surname, string Email, string Password)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LUBNAH\\SQLEXPRESS;Initial Catalog=Stor-E-Books;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

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
            SqlConnection con = new SqlConnection(@"Data Source=LUBNAH\SQLEXPRESS;Initial Catalog=Stor-E-Books;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

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

        public IActionResult ShowItems(string bookName, string Author, string Genre, string Price )
        {
            string bookname, author, genre, price;
            bookname = bookName;
            author = Author;
            genre = Genre;
            price = Price;
            SqlConnection con = new SqlConnection(@"Data Source=LUBNAH\SQLEXPRESS;Initial Catalog=Stor-E-Books;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            
            try
            {
                string Qry = "SELECT * FROM ITEMS WHERE bookname = '" + bookName + "' and author = '" + Author + "' and genre = '" + Genre + "' and price = '" + Price + "'";
                SqlCommand cmd = new SqlCommand(Qry, con);
                cmd.Parameters.AddWithValue("@BookName", bookName);
                cmd.Parameters.AddWithValue("@Author", Author);
                cmd.Parameters.AddWithValue("@Genre", Genre);
                cmd.Parameters.AddWithValue("@Price", Price);

                SqlDataAdapter sda = new SqlDataAdapter(Qry, con);
                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {

                    ViewBag.Message = "";
                    return View(dataTable);

                    //ViewBag.Message = "Login successful!";
                }
                else
                {
                    ViewBag.Message = "No items found matching the criteria";
                }
            }
            catch (Exception ex)
            {

                ViewBag.Message = "An error occurred: " + ex.Message;
            }
            finally
            {
                con.Close();
            }


            return View();

            //adding items into the list 

            //if (ItemsManager.itm.Count == 0)
            //{
            //    ItemsManager.itm.Add(new Items(1, "Harry potter", "J.K Rowling", "Fantasy", 450));
            //    ItemsManager.itm.Add(new Items(2, "Hunger Games", "Suzanne Collins", "Sci-Fi", 350));
            //    ItemsManager.itm.Add(new Items(3, "The Notebook", "Nicholas Sparks", "Romance", 650));
            //    ItemsManager.itm.Add(new Items(4, "Pride and Prejudice", "Jane Austen", "Romance", 600));
            //    ItemsManager.itm.Add(new Items(5, "The Great Gatsby", "F. Scott Fitzgerald", "Clasic", 550));
            //}

            //return View(ItemsManager.itm);
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

    


