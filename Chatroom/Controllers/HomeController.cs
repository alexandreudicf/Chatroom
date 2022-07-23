using Chatroom.Models;
using Chatroom.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Chatroom.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemoryCache _messages;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IMemoryCache messages)
        {
            _logger = logger;
            _messages = messages;
        }

        public IActionResult Index()
        {
            return View(_messages.GetMessagesOrderedByDate());
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
    }
}