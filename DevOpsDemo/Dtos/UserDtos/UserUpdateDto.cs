using DevOpsDemo.Dtos.TodoDtos;

namespace DevOpsDemo.Dtos.UserDtos
{
    public class UserUpdateDto
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
