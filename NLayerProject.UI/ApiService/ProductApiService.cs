﻿using Newtonsoft.Json;
using NLayerProject.UI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.UI.ApiService
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            IEnumerable<ProductDto> productDtos;
            var response = await _httpClient.GetAsync("products");

            if (response.IsSuccessStatusCode)
            {
                productDtos = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                productDtos = null;
            }

            return productDtos;
        }

        public async Task<ProductDto> AddAsync(ProductDto productDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(productDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("products", stringContent);

            if (response.IsSuccessStatusCode)
            {
                productDto = JsonConvert.DeserializeObject<ProductDto>(await response.Content.ReadAsStringAsync());

                return productDto;
            }
            else
            {
                return null;
            }
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"products/{id}");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ProductDto>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Update(ProductDto productDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(productDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("products", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Remove(int id)
        {
            var response = await _httpClient.DeleteAsync($"products/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
