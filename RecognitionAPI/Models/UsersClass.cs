namespace RecognitionAPI.Models
{
    public partial class UsersClass
    {
        public int id { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public int? role_id { get; set; }    
    }
}
