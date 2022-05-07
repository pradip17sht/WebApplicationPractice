using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using WebApplicationPractice.Models;

namespace WebApplicationPractice.Services
{
    public class JsonFileProductService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json");

        public IEnumerable<Product> GetProducts()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }  
        }
    }
}
