using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Utils;

namespace WebApplication1.Entires
{
    public class Todo
    {
        [Key]
        public int? Id { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(500)]
        public string Content { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public TodoStatus? Status { get; set; }

        public TodoTaskName? TaskName  { get; set; }
}

}
