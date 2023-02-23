using Dapper;
using Microsoft.Extensions.Configuration;
using SocialMedia.Business.Interfaces.Repositories;
using SocialMedia.Domain.Entities;
using SocialMedia.Infra.Repositories.BaseRepositories;

namespace SocialMedia.Infra.Repositories
{
    public sealed class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<bool> InsertAsync(User user)
        {
            var dbTransaction = await InicializeTransactionAsync();

            const string insertAddressSlqString = @"INSERT INTO Addresses (Registration_Date,
                Zip_Code,
                Street)
                VALUES (@RegistrationDate,
                @ZipCode,
                @Street);
                
                SELECT CAST(SCOPE_IDENTITY() AS int)";

            var addressId = await _sqlConnection.QueryFirstOrDefaultAsync<int?>(insertAddressSlqString, 
                new { RegistrationDate = DateTime.Now, ZipCode = user.Address.ZipCode, Street = user.Address.ZipCode },
                transaction: dbTransaction);

            if (addressId is null)
                return false;
            
            const string insertUserSqlString = @"INSERT INTO Users(Registration_date,
                Email,
                UserName,
                Address_Id)
                VALUES(@RegistrationDate,
                @Email,
                @UserName,
                @AddressId)";

            var insertUserResult = await _sqlConnection.ExecuteAsync(insertUserSqlString, 
                new { RegistrationDate = DateTime.Now, Email = user.Email, UserName = user.UserName, AddressId = addressId },
                transaction: dbTransaction);

            if(insertUserResult > 0)
                return await CommitTransactionAsync(dbTransaction);

            return false;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var userExistsSqlString = $@"SELECT COUNT(*)
                FROM Users
                WHERE Id = {id}";

            var userExistsResult = await _sqlConnection.QueryFirstOrDefaultAsync<int>(userExistsSqlString);

            return userExistsResult >= 1;
        }

        public async Task<bool> UserNameExistsAsync(string userName)
        {
            var userNameExistsSqlString = $@"SELECT COUNT(*)
                FROM Users
                WHERE UserName = '{userName}'";

            var userNameExistsResult = await _sqlConnection.QueryFirstOrDefaultAsync<int>(userNameExistsSqlString);

            return userNameExistsResult >= 1;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            var emailExistsSqlString = $@"SELECT COUNT(*)
                FROM Users
                WHERE Email = '{email}'";

            var emailExistsResult = await _sqlConnection.QueryFirstOrDefaultAsync<int>(emailExistsSqlString);

            return emailExistsResult >= 1;
        }
    }
}
