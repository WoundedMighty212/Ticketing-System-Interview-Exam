using Microsoft.EntityFrameworkCore;

namespace Ticketing_System_Interview_Exam.Models
{
    public enum BugStatus
    {
        open,
        inprogress,
        resolved,
        closed
    }
    public class Bug
    {
      //  [PrimaryKey("BugId")]
        public int BugId { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public BugStatus Status { get; set; } = BugStatus.open; // Open or Resolved
        public int CreatedByUserId { get; set; }

    }
}
