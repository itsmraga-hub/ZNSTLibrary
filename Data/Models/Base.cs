using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZNSTLibrary.Data.Models
{
    public class Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string CreatedBy { get; set; } = "";
        public string UpdatedBy { get; set; } = "";
        public string DeletedBy { get; set; } = "";

    }
}
