using System.ComponentModel.DataAnnotations;

namespace memobit.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual List<Card> Cards { get; set; }
    }
}
