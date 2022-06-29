namespace TDMUMotelWeb.Models;

public class AccountModel
{
    protected AccountModel(string fullname, string username, string email, string address, string phoneNumber, string avatar)
    {
        Fullname = fullname;
        Username = username;
        Email = email;
        Address = address;
        PhoneNumber = phoneNumber;
        Avatar = avatar;
    }

    public AccountModel()
    {
        throw new NotImplementedException();
    }

    public string Fullname { get; }
    public string Username { get; }
    public string Email { get; }
    public string Address { get; }
    public string PhoneNumber { get; }
    public string Avatar { get; }
    public long UserId { get; set; }
    public int Permission { get; set; }
    public int IsDeleted { get; set; }
}
