using System.ComponentModel.DataAnnotations;

namespace memobit.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Status status { get; set; }
        public virtual Card Card { get; set; }
        public enum Status
        {
            Bad = 0,
            Moderate = 1,
            Good = 2
        }
    }
}
