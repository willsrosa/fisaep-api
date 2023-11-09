using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fisaep.Data;
using Fisaep.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fisaep.Web.Controllers
{
    public class IntegracaoController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IntegracaoController(IHttpContextAccessor httpContextAccessor, ApplicationContext context)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;

        }


        [AllowAnonymous]
        [HttpPost]
        [Route("api/Integracao/BaixarLeads")]
        public ActionResult BaixarLeads([FromBody]RootObject request)
        {
            var obj = new rdstation();
            obj.valor = ToJSON(request);
            _context.Add(obj);
            _context.SaveChanges();
            return Ok();

        }

        public string ToJSON(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}