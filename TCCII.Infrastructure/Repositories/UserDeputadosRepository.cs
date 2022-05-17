using TCCII.Core.Entities;
using TCCII.Core.Interfaces.Repositories;
using TCCII.Infrastructure.Data;
using TCCII.Infrastructure.Repositories.Base;

namespace TCCII.Infrastructure.Repositories
{
    public class UserDeputadosRepository : BaseRepository<UserDeputados>, IUserDeputadosRepository
    {
        public UserDeputadosRepository(DeputadosDbContext context) : base(context)
        {
        }
    }
}
