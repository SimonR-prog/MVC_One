using Data.Context;
using Data.Entities;
using Data.Interfaces;
using Domain.Models;

namespace Data.Repositories;
public class UserRepository(DataContext context) : BaseRepository<UserEntity, User>(context), IUserRepository
{
    //Look at usermanager. Guessing he means I need a separate model which holds certain things from the identities user..
}
