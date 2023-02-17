using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace SocialMedia.Infra.Repositories.BaseRepositories
{
    public abstract class BaseRepository : IDisposable
    {
        private readonly IConfiguration _configuration;
        protected readonly SqlConnection _sqlConnection;

        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected async Task<DbTransaction> InicializeTransactionAsync()
        {
            await _sqlConnection.OpenAsync();
            return await _sqlConnection.BeginTransactionAsync();
        }

        protected async Task<bool> CommitTransactionAsync(DbTransaction dbTransaction)
        {
            try
            {
                await dbTransaction.CommitAsync();
                await _sqlConnection.CloseAsync();

                return true;
            }
            catch
            {
                await dbTransaction.RollbackAsync();
                await _sqlConnection.CloseAsync();

                throw;
            }
        }

        public void Dispose() =>
            _sqlConnection.Dispose();
    }
}
