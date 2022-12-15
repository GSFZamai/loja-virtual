using BkVirtual.Core.Integration;
using BkVirtual.Infrastructure.HttpClients.Pagamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkVirtual.Infrastructure.Pagamentos.Gateways
{
    public class PagSeguroGateway : IPagseguroGateway
    {
        private readonly IHttpClientPagamentoService _httpClientPagamentoService;

        public PagSeguroGateway(IHttpClientPagamentoService httpClientPagamentoService)
        {
            _httpClientPagamentoService = httpClientPagamentoService;
        }

        public async Task<PagSeguroGatewayResponse> EfetivarTransacao(RealizarPagamentoRequest request)
        {
            var dadosPagSeguroRequest = new PagSeguroGatewayRequest
            {
                Descricao = $"Pagamento feito de forma online - id pedido: {request.PedidoId}",
                Cobranca = new Amount
                {
                    Moeda = "BRL",
                    Valor = (int)(request.Total * 100),
                },
                MetodoPagamento = new PaymentMethod
                {
                    Tipo = "CREDIT_CARD",
                    QuantidadeParcelas = 1,
                    CobrancaEmUmPasso = true,
                    NomeFaturaCartao = "Loja BK Virtual",
                    Cartao = new Card
                    {
                        Numero = request.NumeroCartao,
                        CodigoSeguranca = request.CodigoVerificadorCartao,
                        PortadorCartao = new Holder
                        {
                            Nome = request.NomeCartao
                        },
                        VencimentoMes = request.ExpiracaoCartao.Split("/")[0],
                        VencimentoAno = request.ExpiracaoCartao.Split("/")[1],
                    }
                },
                UrlsNotificacao = new List<string>()
            {
                "https://yourserver.com/nas_ecommerce/277be731-3b7c-4dac-8c4e-4c3f4a1fdc46/"
            }
            };

            return await _httpClientPagamentoService.PostAsync<PagSeguroGatewayResponse, PagSeguroGatewayRequest>(
                dadosPagSeguroRequest);
        }
    }
}
