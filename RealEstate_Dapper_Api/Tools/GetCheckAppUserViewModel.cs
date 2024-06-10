namespace RealEstate_Dapper_Api.Tools
{
    public class GetCheckAppUserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string TC { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public bool IsExist { get; set; }
    }
}
