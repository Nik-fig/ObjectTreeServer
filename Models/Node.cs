namespace server.Models
{
    public class Node
    {
        public int Id { get; set; }
        public int[]? Children { get; set; }
        public Dictionary<string, object>? Properties { get; set; }
    }
}
