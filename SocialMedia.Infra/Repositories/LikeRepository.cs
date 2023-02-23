using Dapper;
using Microsoft.Extensions.Configuration;
using SocialMedia.Business.Interfaces.Repositories;
using SocialMedia.Domain.Entities;
using SocialMedia.Infra.Repositories.BaseRepositories;

namespace SocialMedia.Infra.Repositories
{
    public sealed class LikeRepository : BaseRepository, ILikeRepository
    {
        public LikeRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<bool> InsertAsync(Like like)
        {
            var dbTransaction = await InicializeTransactionAsync();

            const string insertLikeSqlString = @"INSERT INTO Likes (Registration_Date,
                User_Id,
                Post_Id)
                VALUES (@RegistrationDate,
                @UserId,
                @PostId)";

            var insertLikeResult = await _sqlConnection.ExecuteAsync(insertLikeSqlString,
                new { RegistrationDate = DateTime.Now, UserId = like.UserId, PostId = like.PostId},
                transaction: dbTransaction);

            if (insertLikeResult > 0)
                return await CommitTransactionAsync(dbTransaction);

            return false;
        }

        public async Task<bool> LikeExistsByRelationshipsAsync(int userId, int postId)
        {
            var likeExistsSqlString = $@"SELECT COUNT(*)
                FROM Likes
                WHERE User_Id = {userId}
                AND Post_Id = {postId}";

            var likeExistsResult = await _sqlConnection.QueryFirstOrDefaultAsync<int>(likeExistsSqlString);

            return likeExistsResult >= 1;
        }

        public async Task<bool> LikeExistsAsync(int id)
        {
            var likeExistsSqlString = $@"SELECT COUNT(*)
                FROM Likes
                WHERE Id = {id}";

            var likeExistsResult = await _sqlConnection.QueryFirstOrDefaultAsync<int>(likeExistsSqlString);

            return likeExistsResult >= 1;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var dbTransaction = await InicializeTransactionAsync();

            var deleteLikeSqlString = $@"DELETE
                FROM Likes
                WHERE Id = {id}";

            var deleteLikeResult = await _sqlConnection.ExecuteAsync(deleteLikeSqlString, transaction: dbTransaction);

            if(deleteLikeResult > 0)
                return await CommitTransactionAsync(dbTransaction);

            return false;
        }
    }
}
