using System.Net.Security;
using FruitStoreApp.Interfaces;
using Xamarin.Android.Net;

namespace FruitStoreApp;

class AndroidHttpMessageHandler : IPlatformHttpMessageHandler
{
    public HttpMessageHandler GetHttpMessageHandler() =>
        new AndroidMessageHandler
        {
            ServerCertificateCustomValidationCallback = (httpRequestMessage, certificate, chain, sslPolicyErrors) =>
                certificate?.Issuer == "CN=localhost" || sslPolicyErrors == SslPolicyErrors.None
        };
}