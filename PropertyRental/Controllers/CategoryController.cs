using Microsoft.AspNetCore.Mvc;
using PropertyRental.Data;
using PropertyRental.Models;

namespace PropertyRental.Controllers
{
    public class CategoryController : Controller
    {
        /// <summary>
        /// Application DB Context Object
        /// </summary>
        /// <returns></returns>

        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Constructor to implement ApplicationDbContext
        /// </summary>
        /// <returns></returns>

        public CategoryController(ApplicationDbContext db)
        {
            _db = db; //Getting the ApplicationDbContext that has already been registered in application
        }

        public IActionResult Index()
        {
            //Access the categories table here via ApplicationDbContext object and categories DbSet
            IEnumerable<Category> objCategoryList = _db.Categories; // Categories is the DbSet defined in ApplicationDbContext

            return View(objCategoryList);
        }
        //Get
        public IActionResult Create()
        {
            return View();
        }

        //Post
        // Called when we post the create category form
        [HttpPost]
        [ValidateAntiForgeryToken] // Helps in preventing cross site request forgery attacks
        public IActionResult Create(Category obj)
        {
            //Add the category object to database
            _db.Categories.Add(obj);
            _db.SaveChanges(); // Saved to database

            //After saving data redirect to index action of category
            return RedirectToAction("Index");
        }
    }
}
