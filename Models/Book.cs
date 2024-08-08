using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BinarTestMandiri.Models
{
    public class Book
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
    }
}
