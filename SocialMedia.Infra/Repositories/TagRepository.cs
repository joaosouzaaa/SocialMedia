using Dapper;
using Microsoft.Extensions.Configuration;
using SocialMedia.Business.Interfaces.Repositories;
using SocialMedia.Domain.Entities;
using SocialMedia.Infra.Repositories.BaseRepositories;

namespace SocialMedia.Infra.Repositories
{
    public sealed class TagRepository : BaseRepository, ITagRepository
    {
        public TagRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<int?> InsertAsync(Tag tag)
        {
            var dbTransaction = await InicializeTransactionAsync();

            const string insertTagSqlString = @"INSERT INTO Tags (Registration_Date,
                Name)
                VALUES (@RegistrationDate,
                @Name);

                SELECT CAST(SCOPE_IDENTITY() as int)";

            var tagIdResult = await _sqlConnection.QueryFirstOrDefaultAsync<int?>(insertTagSqlString,
                new { RegistrationDate = DateTime.Now, Name = tag.Name },
                transaction: dbTransaction);

            if (tagIdResult is not null)
            {
                await CommitTransactionAsync(dbTransaction);

                return tagIdResult;
            }

            return null;
        }

        public async Task<int?> GetTagIdByNameAsync(string name)
        {
            var getTagIdSqlString = $@"SELECT Id
                FROM Tags
                WHERE Name = '{name}'";

            return await _sqlConnection.QueryFirstOrDefaultAsync<int?>(getTagIdSqlString);
        }
    }
}
