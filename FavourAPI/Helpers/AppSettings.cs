using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FavourAPI.Helpers
{
    public class AppSettings : Controller
    {
        public string Secret { get; set; }
    }
}
