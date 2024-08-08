
using BinarTestMandiri.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace BinarTestMandiri.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryContext _dbContext;

        public UserRepository(LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<object> GetAllUsers()
        {
            var userDetails = _dbContext.UserDetails.ToList();
            var users = _dbContext.Users.ToList();
            var query = from user in users
                        join userDetail in userDetails
                        on user.Id equals userDetail.UserId
                        select new
                        {
                            ID = user.Id,
                            UserName = user.Username,
                            Password = user.Password,
                            Email = userDetail.Email,
                            Name = userDetail.Name,
                            Age = userDetail.Age
                        };

            return query.ToList();
        }
    }
}
