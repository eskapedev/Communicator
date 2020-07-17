using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Communicator.WebApp.Models;
using Communicator.Core.Web;
using Communicator.Model.Dtos;
using System.Collections.Specialized;

namespace Communicator.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpHelperForJson _http;

        public HomeController(ILogger<HomeController> logger, IHttpHelperForJson http)
        {
            _logger = logger;
            _http = http;
        }

        public async Task<IActionResult> Index()
        {
            List<TodoDto> model = await _http.GetAsync<List<TodoDto>>("https://localhost:44304/api/Todo/List");
            return View(model);
        }

        public async Task<IActionResult> Todo(string id)
        {
            TodoDto model = await _http.GetAsync<TodoDto>("https://localhost:44304/api/Todo", new NameValueCollection { { "id", id } });
            return View(model);
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
