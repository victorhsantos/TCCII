namespace TCCII.API.Authentication.API.DTOs.RequestModels.Deputados
{
    public class CreateDeputadosRequest
    {
        public int id { get; set; }
        public string email { get; set; }
        public int idLegislatura { get; set; }
        public string nome { get; set; }
        public string siglaPartido { get; set; }
        public string siglaUf { get; set; }
        public string uri { get; set; }
        public string uriPartido { get; set; }
        public string urlFoto { get; set; }
    }
}
