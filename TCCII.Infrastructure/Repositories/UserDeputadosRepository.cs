using TCCII.Deputados.Core.Entities;
using TCCII.Deputados.Core.Interfaces.Repositories;
using TCCII.Deputados.Infrastructure.Data;
using TCCII.Deputados.Infrastructure.Repositories.Base;

namespace TCCII.Deputados.Infrastructure.Repositories
{
    public class UserDeputadosRepository : BaseRepository<UserDeputados>, IUserDeputadosRepository
    {
        public UserDeputadosRepository(DeputadosDbContext context) : base(context)
        {
        }
    }
}
