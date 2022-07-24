using Chatroom.Models;
using Chatroom.Service.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Chatroom.Controllers
{
    /// <summary>
    /// Home Page.
    /// </summary>
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IMemoryCache _messages;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IMemoryCache messages)
        {
            _logger = logger;
            _messages = messages;
        }

        /// <summary>
        /// Default page to be showed. Get lastest messages stored in the memory.
        /// </summary>
        /// <returns>Returns <see cref="IActionResult"/>.</returns>
        public IActionResult Index()
        {
            return View(_messages.GetMessagesOrderedByDate());
        }

        /// <summary>
        /// Shows Privacy page.
        /// </summary>
        /// <returns>Returns <see cref="IActionResult"/>.</returns>
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