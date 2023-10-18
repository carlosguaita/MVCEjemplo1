using Ejemplo1.Models;
using Newtonsoft.Json;

namespace Ejemplo1.Services
{
    public class APIService : IAPIService
    {

        private static string _baseUrl;

        public APIService() {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            _baseUrl = builder.GetSection("ApiSettings:BaseUrl").Value;
           
        } 
        public Task<string> DeleteProducto(int IdProdcuto)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> GetProducto(int IdProducto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Producto>> GetProductos()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri( _baseUrl );
            var response = await httpClient.GetAsync( "api/Producto/");
            var json_response  = await response.Content.ReadAsStringAsync();
            List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(json_response);
            return productos;

        }

        public Task<Producto> PostProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> PutProducto(int IdProducto, Producto producto)
        {
            throw new NotImplementedException();
        }
    }
}
