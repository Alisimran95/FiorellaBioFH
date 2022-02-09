using System.Linq;
using System.Net.WebSockets;
using FiorellaBackToFrontProject.DataAccessLayer;
using FiorellaBackToFrontProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiorellaBackToFrontProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;
        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var sliderImages = _dbContext.SliderImages.ToList();
            var slider = _dbContext.Sliders.SingleOrDefault();
            var categories = _dbContext.Categories.ToList();
            var products = _dbContext.Products.Include(x=>x.Category).ToList();
            var aboutContexts = _dbContext.AboutContexts.Include(x=>x.AboutIcons).ToList();
            var aboutIcons = _dbContext.AboutIcons.ToList();
            var flowerTitle = _dbContext.FlowerTitles.SingleOrDefault();
            var flowerExperts = _dbContext.FlowerExperts.ToList();
            var subscribes = _dbContext.Subscribes.FirstOrDefault();
            var blog = _dbContext.Blogs.SingleOrDefault();
            var blogItems = _dbContext.BlogItems.ToList();
            var instagrams = _dbContext.Instagrams.ToList();

            return View(new HomeViewModel
                {
                SliderImages = sliderImages,
                Slider = slider,
                Categories = categories,
                Products = products,
                AboutContexts = aboutContexts,
                AboutIcons = aboutIcons,
                FlowerExperts = flowerExperts,
                FlowerTitle = flowerTitle,
                Subscribe = subscribes,
                Blog = blog,
                BlogItems = blogItems,
                Instagrams = instagrams,
                });
        }
    }
}
