using Dapper;
using Microsoft.Extensions.Configuration;
using SocialMedia.Business.Interfaces.Repositories;
using SocialMedia.Domain.Entities;
using SocialMedia.Infra.Repositories.BaseRepositories;

namespace SocialMedia.Infra.Repositories
{
    public sealed class PostRepository : BaseRepository, IPostRepository
    {
        public PostRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<bool> InsertAsync(Post post, List<int> tagIds)
        {
            var dbTransaction = await InicializeTransactionAsync();

            const string insertPostSqlString = @"INSERT INTO Posts (Registration_Date, 
                Text, 
                User_Id) 
                VALUES (@RegistrationDate, 
                @Text, 
                @UserId); 
                
                SELECT CAST(SCOPE_IDENTITY() as int)";

            var postIdInsertResult = (await _sqlConnection.QueryAsync<int>(insertPostSqlString,
                new { RegistrationDate = DateTime.Now, Text = post.Text, UserId = post.UserId },
                transaction: dbTransaction)).FirstOrDefault();

            const string insertTagPostSqlString = @"INSERT INTO TagsPosts (Post_Id, 
                Tag_Id) 
                VALUES (@PostId, 
                @TagId)";
            
            var insertPostResult = await _sqlConnection.ExecuteAsync(insertTagPostSqlString,
                tagIds.Select(tagId => new { PostId = postIdInsertResult, TagId = tagId }),
                transaction: dbTransaction);

            if (insertPostResult > 0)
                return await CommitTransactionAsync(dbTransaction);

            return false;
        }
    }
}
