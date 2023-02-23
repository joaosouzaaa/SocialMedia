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

        public async Task<bool> ExistsAsync(int id)
        {
            var postExistsSqlString = $@"SELECT COUNT(*)
                FROM Posts
                WHERE Id = {id}";

            var postExistsResult = await _sqlConnection.QueryFirstOrDefaultAsync<int>(postExistsSqlString);

            return postExistsResult >= 1;
        }

        public async Task<List<Post>> GetAllPostsFromUserAsync(int userId)
        {
            var getAllPostSqlString = $@"SELECT P.Id,
                P.Text,
                P.Registration_Date AS RegistrationDate,
                P.User_Id AS UserId,
                U.Id,
                U.Email,
                U.UserName,
                A.Id,
                A.Zip_Code AS ZipCode,
                A.Street,
                T.Id,
                T.Name,
                L.Id,
                L.User_Id AS UserId,
                L.Post_Id AS PostId
                FROM Posts P
                INNER JOIN Users U
                ON U.Id = P.User_Id
                INNER JOIN Addresses A
                ON A.Id = U.Address_Id
                INNER JOIN TagsPosts TP
                ON TP.Post_Id = P.Id
                INNER JOIN Tags T
                ON T.Id = TP.Tag_Id
                INNER JOIN Likes L
                ON L.Post_Id = P.Id
                WHERE U.Id = {userId}";

            var getAllPostsDictionary = new Dictionary<int, Post>();

            var getAllPostsResult = await _sqlConnection.QueryAsync<Post, User, Address, Tag, Like, Post>(getAllPostSqlString,
                (post, user, address, tags, likes) =>
                {
                    if(!getAllPostsDictionary.TryGetValue(post.Id, out Post postResult))
                    {
                        postResult = post;
                        post.Tags = new List<Tag>();
                        post.Likes = new List<Like>();
                        getAllPostsDictionary.Add(post.Id, post);
                    }

                    postResult.User = user;
                    postResult.User.Address = address;

                    if(!postResult.Tags.Any(t => t.Id == tags.Id))
                        postResult.Tags.Add(tags);

                    if(!postResult.Likes.Any(l => l.Id == likes.Id))
                        postResult.Likes.Add(likes);

                    return postResult;
                }, splitOn: "UserId, Id, Id, Id");

            return getAllPostsResult.Distinct().ToList();
        }
    }
}
