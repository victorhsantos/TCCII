using TCCII.Deputados.Infrastructure.Data;
using TCCII.Deputados.Core.Interfaces.Repositories;
using TCCII.Deputados.Core.Interfaces.Repositories.Base;

namespace TCCII.Deputados.Infrastructure.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DeputadosDbContext _contexto;

        DeputadosRepository deputadosRepository = null;
        UserDeputadosRepository userDeputadosRepository = null;
        DespesasRepository despesasRepository = null;        

        public UnitOfWork(DeputadosDbContext contexto)
        {
            _contexto = contexto;
        }

        public void Commit() =>
            _contexto.SaveChanges();


        public IDeputadosRepository DeputadosRepository
        {
            get
            {
                if (deputadosRepository == null)
                    deputadosRepository = new DeputadosRepository(_contexto);

                return deputadosRepository;
            }
        }

        public IUserDeputadosRepository UserDeputadosRepository
        {
            get
            {
                if (userDeputadosRepository == null)
                    userDeputadosRepository = new UserDeputadosRepository(_contexto);

                return userDeputadosRepository;
            }
        }

        public IDespesasRepository DespesasRepository
        {
            get
            {
                if (despesasRepository == null)
                    despesasRepository = new DespesasRepository(_contexto);

                return despesasRepository;
            }
        }        

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _contexto.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
