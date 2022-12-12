using Dapper;
using DeppoControlBackend.Result;
using IResult = DeppoControlBackend.Result.IResult;

namespace DeppoControlBackend.Repository
{
    public interface IDapperRepository<T> where T : class, new()
    {
        IDataResult<IEnumerable<T>> Get(string query, DynamicParameters p);
        Task<IDataResult<IEnumerable<T>>> GetAsync(string query, DynamicParameters p);
        IDataResult<T> GetById(string query, DynamicParameters p);
        Task<IDataResult<T>> GetByIdAsync(string query, DynamicParameters p);
        IDataResult<IEnumerable<T>> GetAll(string query);
        Task<IDataResult<IEnumerable<T>>> GetAllAsync(string query);
        IDataResult<T> FirstOrDefault(string query, DynamicParameters p);
        Task<IDataResult<T>> FirstOrDefaultAsync(string query, DynamicParameters p);
        IResult ExecuteQuery(string query);
        Task<IResult> ExecuteQueryAsync(string query);
        IResult ExecuteQuery(string query, DynamicParameters p);
        Task<IResult> ExecuteQueryAsync(string query, DynamicParameters p);
        IResult ExecuteProcedure(string query);
        Task<IResult> ExecuteProcedureAsync(string query);
        IResult ExecuteProcedure(string query, DynamicParameters p);
        Task<IResult> ExecuteProcedureAsync(string query, DynamicParameters p);
        IDataResult<IEnumerable<T>> GetWithProcedure(string query, DynamicParameters p);
        Task<IDataResult<IEnumerable<T>>> GetWithProcedureAsync(string query, DynamicParameters p);
        Task<object> ExecuteScalarAsync(string query);
    }
}

