namespace memobit.Data.Dto
{
    public class AnswerDto
    {
        public Status status { get; set; }
        public enum Status
        {
            Bad = 0,
            Moderate = 1,
            Good = 2
        }
    }
}
