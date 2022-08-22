using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace memobit.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int DaysNextAnswer { get; set; }
        [Required]
        public DateTime LastAnswerDate { get; set; }
        public int GroupId { get; set; }
        [JsonIgnore]
        public virtual Group Group { get; set; }
        [JsonIgnore]
        public virtual List<Answer> Answers { get; set; }
    }
}
