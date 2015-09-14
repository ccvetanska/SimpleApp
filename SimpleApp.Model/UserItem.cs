namespace SimpleApp.Model
{
    /// <summary>
    /// Defines the structure of a UserItem. Acts like a contract between the layers.
    /// </summary>
    public class UserItem
    {            
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
