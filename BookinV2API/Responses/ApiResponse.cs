namespace BookinV2API.Responses
{
    public class ApiResponse<T>
    {
        public bool IsSucceeded { get; set; } = false;
        public T? Response { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }

}
