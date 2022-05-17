using TCCII.Core.Entities.Identity;

namespace TCCII.Core.Entities
{
    public class UserDeputados
    {
        public UserDeputados(int userId, int deputadosId)
        {
            UserId = userId;
            DeputadosId = deputadosId;
        }

        public int UserId { get; set; }
        public int DeputadosId { get; set; }

        public virtual User User { get; set; }
        public virtual Deputados Deputado { get; set; }
    }
}
