using Isapel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Isapel.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private SinaScraper SinaScraper = new SinaScraper();

        public List<Producto> ListaProductos;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            ListaProductos = SinaScraper.GetProductos();
        }

        public void OnGet()
        {

        }
    }
}
