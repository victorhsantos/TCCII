namespace TCCII.API.Authentication.API.DTOs.ResponseModels.Deputados
{
    public class DeputadosResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int IdLegislatura { get; set; }
        public string Nome { get; set; }
        public string SiglaPartido { get; set; }
        public string SiglaUf { get; set; }
        public string Uri { get; set; }
        public string UriPartido { get; set; }
        public string UrlFoto { get; set; }
    }
}
