using Application.IServices;
using Microsoft.Extensions.Configuration;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using PayPalCheckoutSdk.Payments; // Required for Refunds
using PayPalHttp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PayPalService : IPayPalService
    {
        private readonly PayPalHttpClient _payPalHttpClient;

        public PayPalService(IConfiguration configuration)
        {
            var clientId = configuration["PayPal:ClientId"];
            var clientSecret = configuration["PayPal:ClientSecret"];
            var environment = new SandboxEnvironment(clientId, clientSecret);
            _payPalHttpClient = new PayPalHttpClient(environment);
        }

        public async Task<Order> CreateOrderAsync(decimal amount, string currency)
        {
            var request = new OrdersCreateRequest();
            request.Prefer("return=representation");
            request.RequestBody(new OrderRequest
            {
                CheckoutPaymentIntent = "CAPTURE",
                PurchaseUnits = new List<PurchaseUnitRequest>
                {
                    new PurchaseUnitRequest
                    {
                        AmountWithBreakdown = new AmountWithBreakdown
                        {
                            CurrencyCode = currency,
                            Value = amount.ToString("F2")
                        }
                    }
                }
            });

            var response = await _payPalHttpClient.Execute(request);
            return response.Result<Order>();
        }

        public async Task<Order> CaptureOrderAsync(string orderId)
        {
            var request = new OrdersCaptureRequest(orderId);
            request.RequestBody(new OrderActionRequest());

            var response = await _payPalHttpClient.Execute(request);
            return response.Result<Order>();
        }

        /// <summary>
        /// Issues a refund for a previously captured PayPal payment.
        /// </summary>
        public async Task<HttpResponse> RefundPaymentAsync(string captureId, decimal amount, string currency)
        {
            var request = new CapturesRefundRequest(captureId);
            request.Prefer("return=representation");
            request.RequestBody(new RefundRequest()
            {
                // Use the fully qualified name to resolve the ambiguity
                Amount = new PayPalCheckoutSdk.Payments.Money
                {
                    CurrencyCode = currency,
                    Value = amount.ToString("F2")
                }
            });

            var response = await _payPalHttpClient.Execute(request);
            return response;
        }
    }
}