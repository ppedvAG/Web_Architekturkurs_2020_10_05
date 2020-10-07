using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RazorPageSample.Pages
{
    //Die Klasse IndexModel kann man als ein ViewModel betrachten 
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;

        
        public string Vorname = "Kevin";

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
