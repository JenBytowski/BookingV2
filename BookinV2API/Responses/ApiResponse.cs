namespace BookinV2API.Responses
{
    public class ApiResponse<T>
    {
        public bool IsSucceeded { get; set; } = true;

        public T? Response { get; set; }

        public List<string> Errors { get; set; } = new List<string>();

        public void AddError(string error)
        {
            this.IsSucceeded = false;
            this.Errors.Add(error);
        }
    }
}
