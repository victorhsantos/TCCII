namespace TCCII.Deputados.API.DTOs.RequestModels.Despesas
{
    public class CreateDespesasRequest
    {
        public int DeputadoID { get; set; }
        public List<DespesasRequest> Despesas { get; set; }
    }

    public class DespesasRequest
    {
        public string cnpjCpfFornecedor { get; set; }
        public int codDocumento { get; set; }
        public int codLote { get; set; }
        public int codTipoDocumento { get; set; }
        public string dataDocumento { get; set; }
        public int mes { get; set; }
        public int ano { get; set; }
        public string nomeFornecedor { get; set; }
        public string numDocumento { get; set; }
        public string numRessarcimento { get; set; }
        public int parcela { get; set; }
        public string tipoDespesa { get; set; }
        public string tipoDocumento { get; set; }
        public string urlDocumento { get; set; }
        public double valorDocumento { get; set; }
        public double valorGlosa { get; set; }
        public double valorLiquido { get; set; }

    }
}
