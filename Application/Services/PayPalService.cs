// Application/Services/PayPalService.cs
using Application.IServices;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Application.Services
{
    public class PayPalService : IPayPalService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public PayPalService(IConfiguration configuration)
        {
            _configuration = configuration;
            var payPalConfig = _configuration.GetSection("PayPal");
            var baseAddress = payPalConfig["Mode"] == "sandbox"
                ? "https://api-m.sandbox.paypal.com"
                : "https://api-m.paypal.com";

            _httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
        }

        private async Task<string> GetAccessTokenAsync()
        {
            var payPalConfig = _configuration.GetSection("PayPal");
            var clientId = payPalConfig["ClientId"];
            var clientSecret = payPalConfig["ClientSecret"];

            var request = new HttpRequestMessage(HttpMethod.Post, "/v1/oauth2/token");
            request.Headers.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"))
            );
            request.Content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseStream = await response.Content.ReadAsStreamAsync();
            var authResult = await JsonSerializer.DeserializeAsync<JsonElement>(responseStream);

            return authResult.GetProperty("access_token").GetString();
        }

        public async Task<string> CreateOrderAsync(decimal amount, string currency)
        {
            var accessToken = await GetAccessTokenAsync();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var orderRequest = new
            {
                intent = "CAPTURE",
                purchase_units = new[]
                {
                    new
                    {
                        amount = new
                        {
                            currency_code = currency,
                            value = amount.ToString("F2")
                        }
                    }
                }
            };

            var jsonRequest = JsonSerializer.Serialize(orderRequest);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/v2/checkout/orders", content);
            response.EnsureSuccessStatusCode();

            var responseStream = await response.Content.ReadAsStreamAsync();
            var orderResult = await JsonSerializer.DeserializeAsync<JsonElement>(responseStream);

            return orderResult.GetProperty("id").GetString();
        }

        public async Task<string> CaptureOrderAsync(string orderId)
        {
            var accessToken = await GetAccessTokenAsync();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var content = new StringContent("{}", Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/v2/checkout/orders/{orderId}/capture", content);
            response.EnsureSuccessStatusCode();

            var responseStream = await response.Content.ReadAsStreamAsync();
            var captureResult = await JsonSerializer.DeserializeAsync<JsonElement>(responseStream);

            return captureResult.GetProperty("purchase_units")[0].GetProperty("payments").GetProperty("captures")[0].GetProperty("id").GetString();
        }

        public async Task<string> RefundPaymentAsync(string captureId, decimal amount, string currency)
        {
            var accessToken = await GetAccessTokenAsync();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var refundRequest = new
            {
                amount = new
                {
                    value = amount.ToString("F2"),
                    currency_code = currency
                }
            };

            var jsonRequest = JsonSerializer.Serialize(refundRequest);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"/v2/payments/captures/{captureId}/refund", content);
            response.EnsureSuccessStatusCode();

            var responseStream = await response.Content.ReadAsStreamAsync();
            var refundResult = await JsonSerializer.DeserializeAsync<JsonElement>(responseStream);

            return refundResult.GetProperty("id").GetString();
        }
    }
}