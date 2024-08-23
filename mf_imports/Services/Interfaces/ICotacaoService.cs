namespace mf_imports.Services.Interfaces;

public interface ICotacaoService
{
    public Task<decimal> ObterCotacaoDolarAsync();
}