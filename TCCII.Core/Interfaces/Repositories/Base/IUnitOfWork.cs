namespace TCCII.Deputados.Core.Interfaces.Repositories.Base
{
    public interface IUnitOfWork
    {
        IDeputadosRepository DeputadosRepository { get; }
        IUserDeputadosRepository UserDeputadosRepository { get; }
        IDespesasRepository DespesasRepository { get; }        

        void Commit();
    }
}
