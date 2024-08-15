﻿namespace mf_imports.Model;

public class EstoqueMovimenta
{
    public int Id { get; set; }
    public int IdEstoqueLocalOrigem { get; set; }
    public EstoqueLocal EstoqueLocalOrigem { get; set; }

    public int IdEstoqueLocalDestino { get; set; }
    public EstoqueLocal EstoqueLocalDestino { get; set; }

    public int IdProduto { get; set; }
    public Produto Produto { get; set; }

    public int NumeroNF { get; set; }
    public int SerieNF { get; set; }
    public decimal Quantidade { get; set; }
    public DateTime DataHora { get; set; }
    public string Usuario { get; set; }
}