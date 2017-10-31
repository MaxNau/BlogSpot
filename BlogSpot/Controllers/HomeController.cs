using BlogSpot.DAL.Repositories;
using BlogSpot.Models;
using System.Web.Mvc;

namespace BlogSpot.Controllers
{
    public class HomeController : Controller
    {
        private IPostsRepository repository;
        public HomeController(IPostsRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Posts(int pageNumber = 1)
        {
            var posts = repository.GetPostsRange(pageNumber - 1, 10);
            var totalPosts = repository.TotalPosts();
            ListViewModel lvm = new ListViewModel()
            {
                Posts = posts,
                TotalPosts = totalPosts
            };

            ViewBag.Title = "Latest Posts";

            return View("List", lvm);    
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult AboutMe()
        {
            return View();
        }
    }
}