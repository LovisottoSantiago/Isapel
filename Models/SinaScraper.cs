using HtmlAgilityPack;
using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Globalization;

namespace Isapel.Models {
    /*  GENERAL SCRAPING
        1. dotnet add package HtmlAgilityPack 
        2. dotnet add package HtmlAgilityPack.CssSelectors
        3. var web = new HtmlWeb();
        4. var document = web.Load("https://www.scrapingcourse.com/ecommerce/");
    */

    public class SinaScraper {

        private HtmlWeb web;
        private HtmlDocument documento;
        private List<Producto> productos;
        private IEnumerable<HtmlNode> productosHTML;

        public SinaScraper() {
            web = new HtmlWeb();
            documento = web.Load("https://www.scrapingcourse.com/ecommerce/");
            productos = new List<Producto>();
            productosHTML = documento.DocumentNode.QuerySelectorAll("li.product");
            
            foreach (var product in productosHTML) {

                var url = HtmlEntity.DeEntitize(product.QuerySelector("a").Attributes["href"].Value);
                var imagen = HtmlEntity.DeEntitize(product.QuerySelector("img").Attributes["src"].Value);
                var nombre = HtmlEntity.DeEntitize(product.QuerySelector("h2").InnerText);
                var precioTexto = HtmlEntity.DeEntitize(product.QuerySelector(".price").InnerText);
                var precio = float.Parse(precioTexto.Replace("$", "").Replace(",", "").Trim(), CultureInfo.InvariantCulture);

                var newProduct = new Producto() { Url = url, Imagen = imagen, Nombre = nombre, Precio = precio };

                productos.Add(newProduct);

            }

        }

        public List<Producto> GetProductos() {
            return productos;
        }


    }
}
