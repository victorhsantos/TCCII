using TCCII.Deputados.Core.Entities;
using TCCII.Deputados.Core.Interfaces.Repositories;
using TCCII.Deputados.Infrastructure.Data;
using TCCII.Deputados.Infrastructure.Repositories.Base;

namespace TCCII.Deputados.Infrastructure.Repositories
{
    public class DeputadosRepository : BaseRepository<Deputado>, IDeputadosRepository
    {
        public DeputadosRepository(DeputadosDbContext context) : base(context)
        {
        }
    }
}
