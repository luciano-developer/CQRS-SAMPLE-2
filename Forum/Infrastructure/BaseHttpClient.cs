﻿using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class BaseHttpClient
    {
        private readonly HttpClient httpClient;

        protected BaseHttpClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        protected async Task<T> Get<T>(string uri)
        {
            var request = CreateRequest(HttpMethod.Get, uri);

            return await ExecuteRequest<T>(request);
        }
        protected async Task<T> Post<T>(string uri, object content)
        {
            var request = CreateRequest(HttpMethod.Post, uri, content);

            return await ExecuteRequest<T>(request);
        }

        private async Task<T> ExecuteRequest<T>(HttpRequestMessage request)
        {
            try
            {
                var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                    .ConfigureAwait(false);

                var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                response.EnsureSuccessStatusCode();

                return string.IsNullOrEmpty(responseContent) ? default : JsonSerializer.Deserialize<T>(responseContent);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException ||
            ex is HttpRequestException || ex is JsonException)
            {

                throw new Exception("HttpClient exception", ex);
            }
        }

        private static HttpRequestMessage CreateRequest(HttpMethod httpMethod, string uri, object content = null)
        {
            var request = new HttpRequestMessage(httpMethod, uri);
            if (content == null) return request;

            //serialize content
            var json = JsonSerializer.Serialize(content);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return request;
        }
    }
}
