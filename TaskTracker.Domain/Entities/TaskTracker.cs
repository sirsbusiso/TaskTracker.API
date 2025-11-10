using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskTracker.Domain.Entities
{
    [Table("Task")]
    public class TaskEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        public required string Title { get; set; }
        [MaxLength(1000)]
        public required string Description { get; set; }
        public Status Status { get; set; } = Status.New;
        public Priority Priority { get; set; }
        public string? DueDate { get; set; }
        public required string CreatedAt { get; set; }
    }

    public enum Status
    {
        New,
        InProgress,
        Done
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }
}

