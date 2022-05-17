using TCCII.Core.Entities;
using TCCII.Core.Interfaces.Repositories;
using TCCII.Infrastructure.Data;
using TCCII.Infrastructure.Repositories.Base;

namespace TCCII.Infrastructure.Repositories
{
    public class DeputadosRepository : BaseRepository<Deputados>, IDeputadosRepository
    {
        public DeputadosRepository(DeputadosDbContext context) : base(context)
        {
        }
    }
}
