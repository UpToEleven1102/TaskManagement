using System;

namespace HuyenVu.TaskManagement.Core.Entities
{
    public class TaskHistory
    {
        public int TaskId { get; set; }
        
        public int? UserId { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public DateTime? DueDate { get; set; }

        public DateTime? Completed { get; set; }
        
        public string Remarks { get; set; }
        
        public User User { get; set; }
    }
}