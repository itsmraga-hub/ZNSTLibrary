using System.ComponentModel.DataAnnotations.Schema;

namespace ZNSTLibrary.Data.Models
{
    [Table("Categories")]
    public class Category : Base
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

    }
}
