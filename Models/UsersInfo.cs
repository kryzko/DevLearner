using Microsoft.AspNetCore.Mvc;

namespace DevLearner.Models
{
    public class UsersInfo
    {
        public int Id { get; set; }

        [BindProperty]
        public int ProjectId { get; set; }

        [BindProperty]
        public string Name { get; set; }

        UsersInfo() { }

    }
}
