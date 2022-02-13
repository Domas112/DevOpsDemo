using DevOpsDemo.DataContexts;
using DevOpsDemo.Models;

namespace DevOpsDemo.Repositories
{
    public class UsersRepo : IUsersRepo
    {
        private readonly MainDbContext _ctx;
        public UsersRepo(MainDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<User?> CreateUser(User user)
        {
            await _ctx.Users.AddAsync(user);
            _ctx.SaveChanges();

            return _ctx.Users.FirstOrDefault(u => u.Id== user.Id);
        }

        public async Task<ICollection<User>?> DeleteUser(Guid id)
        {
            User? toBeRemoved = _ctx.Users.FirstOrDefault(u => u.Id == id);
            if (toBeRemoved == null) return null;
            
            _ctx.Users.Remove(toBeRemoved);
            await _ctx.SaveChangesAsync();

            return _ctx.Users.ToList();
        }

        public async Task<ICollection<User>?> GetAllUsers()
        {
            ICollection<User> users = _ctx.Users.ToList();
            foreach(User user in users)
            {
                user.TodoList = (
                    from todo in _ctx.Todos
                    where todo.UserId == user.Id
                    select todo
                    ).ToList();
            }
            return _ctx.Users.ToList();
        }

        public async Task<User?> GetUserById(Guid id)
        {
            User user = await _ctx.Users.FindAsync(id);

            user.TodoList = (from todo in _ctx.Todos
                             where todo.UserId == user.Id
                             select todo).ToList();

            return user;
        }

        public async Task<User?> UpdateUser(User user)
        {
            _ctx.Users.Update(user);
            await _ctx.SaveChangesAsync();
            return await _ctx.Users.FindAsync(user.Id);
        }
    }
}
