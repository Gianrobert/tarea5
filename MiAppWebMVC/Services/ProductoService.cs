using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiAppWebMVC.Models;

namespace MiAppWebMVC.Services
{
    public class ProductoService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://localhost:7237/api/productos";

        public ProductoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Producto>> GetProductosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Producto>>(_apiUrl);
        }

        public async Task<Producto> GetProductoByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Producto>($"{_apiUrl}/{id}");
        }

        public async Task CreateProductoAsync(Producto producto)
        {
            await _httpClient.PostAsJsonAsync(_apiUrl, producto);
        }

        public async Task UpdateProductoAsync(Producto producto)
        {
            await _httpClient.PutAsJsonAsync($"{_apiUrl}/{producto.Id}", producto);
        }

        public async Task DeleteProductoAsync(int id)
        {
            await _httpClient.DeleteAsync($"{_apiUrl}/{id}");
        }
    }
}

