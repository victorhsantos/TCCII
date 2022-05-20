using TCCII.Deputados.Core.Entities.Base;

namespace TCCII.Deputados.Core.Entities
{
    public class Deputado : BaseEntity
    {
        public int IdDeputado { get; set; }
        public string Email { get; set; }
        public int IdLegislatura { get; set; }
        public string Nome { get; set; }
        public string SiglaPartido { get; set; }
        public string SiglaUf { get; set; }
        public string Uri { get; set; }
        public string UriPartido { get; set; }
        public string UrlFoto { get; set; }

        public virtual ICollection<UserDeputados> Users { get; set; }
    }
}
