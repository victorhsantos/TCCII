namespace TCCII.Infrastructure.ChargeDatabase
{
    public class CustomResponseDadosAbertos<T>
    {

        public List<T> dados { get; set; }
        public List<LinksResponse> links { get; set; }
    }
}
