using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BinarTestMandiri.Models
{
    public class Transaction
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime Dt => DateTime.Now;
    }
}
