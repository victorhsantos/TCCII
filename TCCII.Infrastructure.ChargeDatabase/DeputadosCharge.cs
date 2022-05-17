using RestSharp;
using System.Text.Json;
using TCCII.Infrastructure.ChargeDatabase.Models;

namespace TCCII.Infrastructure.ChargeDatabase
{
    public static class DeputadosCharge
    {

        public static void CargaDeputados()
        {
            try
            {
                var deputados = GetDeputadosAPI();
                PostDeputadosAPI(deputados);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static List<DeputadosModels> GetDeputadosAPI()
        {
            var client = new RestClient("https://dadosabertos.camara.leg.br/");
            var request = new RestRequest("api/v2/deputados", Method.GET) { RequestFormat = DataFormat.Json };
            request.AddHeader("accept", "application/json");
            request.AddQueryParameter("ordem", "ASC");
            request.AddQueryParameter("ordenarPor", "nome");
            var response = client.Execute(request);
            if (response == null) throw new Exception("Não foi possivel comunicar com a API Dados Abertos");

            var resposta = JsonSerializer.Deserialize<CustomResponseDadosAbertos<DeputadosModels>>(response.Content);
            return resposta.dados;
        }

        private static void PostDeputadosAPI(List<DeputadosModels> deputados)
        {
            var client = new RestClient("http://localhost:5206/");
            var request = new RestRequest("api/deputados/create", Method.POST);
            request.AddHeader("accept", "application/json");
            request.AddHeader("Content-Type", "application/json");            
            request.AddJsonBody(deputados);
            var response = client.Post(request);
            if (response == null) throw new Exception("Não foi possivel comunicar com a API Dados Abertos");            
        }
    }
}
