using TDMUMotelWeb.Data;
using TDMUMotelWeb.Helper;
using TDMUMotelWeb.Models;

namespace TDMUMotelWeb.Repositories;

public class AccountRepository
{
    private static AccountRepository? _instance;
    public static AccountRepository Instance => _instance ??= new AccountRepository();
    
    public void AddUser(AccountModel accountModel)
    {
        try
        {
            AccountData.Instance.AddUser(accountModel);
        }
        catch (Exception e)
        {
            throw new Exception($"AccountRepositories => AddUser, Error: {e}");
        }
    }

    public List<AccountModel>? GetUserInfo(long userId)
    {
        try
        {
            return AccountData.Instance.GetUserInfo(userId).ToList<AccountModel>();
        }
        catch (Exception e)
        {
            throw new Exception($"AccountRepositories => GetUserInfo, Error: {e}");
        }
    }
}