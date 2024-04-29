using Microsoft.AspNetCore.Mvc;

namespace DevLearner.Models
{
    public class UsersInfo
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }


    }
}
