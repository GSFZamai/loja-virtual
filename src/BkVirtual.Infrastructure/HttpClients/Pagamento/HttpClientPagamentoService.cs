using BkVirtual.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BkVirtual.Infrastructure.HttpClients.Pagamento
{
    public class HttpClientPagamentoService : IHttpClientPagamentoService
    {
        private readonly HttpClient _httpClient;
        private readonly PagamentoConfig _configuracoesPagamento;

        public HttpClientPagamentoService(HttpClient httpClient, PagamentoConfig configuracoesPagamento)
        {
            _httpClient = httpClient;
            _configuracoesPagamento = configuracoesPagamento;
        }

        public async Task<TResponse> PostAsync<TResponse, TRequest>(TRequest dados)
            where TResponse : class
            where TRequest : class
        {
            _httpClient.BaseAddress = new Uri(_configuracoesPagamento.UrlAPI);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_configuracoesPagamento.Token);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var requisicao = new HttpRequestMessage(HttpMethod.Post, "charges");
            requisicao.Content = new StringContent(JsonSerializer.Serialize(dados), Encoding.UTF8, MediaTypeNames.Application.Json); ;
            requisicao.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using var resultado = await _httpClient.SendAsync(requisicao);

            if(resultado.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<TResponse>(await resultado.Content.ReadAsStringAsync());
            }

            return null;
        }
    }
}
