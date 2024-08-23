using mf_imports.Services.Interfaces;
using Newtonsoft.Json.Linq;

namespace mf_imports.Services;

public class CotacaoService : ICotacaoService
{
    private readonly HttpClient _httpClient;

    public CotacaoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<decimal> ObterCotacaoDolarAsync()
    {
        var response = await _httpClient.GetAsync("https://economia.awesomeapi.com.br/last/USD-BRL");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(content);
            var cotacao = json["USDBRL"]["bid"].Value<decimal>();

            return cotacao;
        }

        throw new Exception("Não foi possível obter a cotação do dólar.");
    }
}
