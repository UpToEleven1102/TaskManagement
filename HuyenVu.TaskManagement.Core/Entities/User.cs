using System.Collections.Generic;

namespace HuyenVu.TaskManagement.Core.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public string MobileNo { get; set; }
        
        public virtual IEnumerable<Task> Tasks { get; set; }
        
        public virtual IEnumerable<TaskHistory> TaskHistories { get; set; }
        
        public virtual IEnumerable<Role> Roles { get; set; }
    }
}