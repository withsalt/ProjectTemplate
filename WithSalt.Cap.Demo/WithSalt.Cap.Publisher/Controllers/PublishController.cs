using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WithSalt.Cap.Publisher.Controllers
{
    public class PublishController : Controller
    {
        private readonly ICapPublisher _capBus;

        public PublishController(ICapPublisher capBus)
        {
            _capBus = capBus ?? throw new ArgumentNullException(nameof(ICapPublisher));
        }

        public IActionResult Index(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                throw new Exception("Content can nou null.");
            }

            _capBus.Publish("DefaultCapDemo", content);
            return Content($"内容已发布：{content}");
        }
    }
}
