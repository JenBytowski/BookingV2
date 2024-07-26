namespace BookingV2.Logic.Responses
{
    public class ServiceResult<T>
    {
        public T? Response { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public bool IsSuccessful => Errors.Count == 0;

        public void AddError(string error)
        {
            Errors.Add(error);
        }
    }
}
