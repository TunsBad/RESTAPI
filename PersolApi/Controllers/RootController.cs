using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersolApi.Models;

namespace PersolApi.Controllers
{
    [Route("api")]
    public class RootController : Controller
    {
       private IUrlHelper _urlHelper; 
       public RootController (IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }

        [HttpGet(Name = "GetRoot")]
        public IActionResult GetRoot([FromHeader(Name = "Accept")] string mediaType)
        {
            if (mediaType == "application/vnd.marvin.hateoas+json")
            {
                var links = new List<LinkDto>();

                links.Add(new LinkDto(_urlHelper.Link("GetRoot", new { }), "self", "GET"));
                links.Add(new LinkDto(_urlHelper.Link("GetAuthors", new { }), "Authors", "GET"));
                links.Add(new LinkDto(_urlHelper.Link("CreateAuthor", new { }), "CreateAuthor", "POST"));
                //links.Add(new LinkDto(_urlHelper.Link("GetBooksForAuthor", new { }), "BooksForAuthor", "GET"));

                return Ok(links);
            }

            return NoContent();
        }
    }
}