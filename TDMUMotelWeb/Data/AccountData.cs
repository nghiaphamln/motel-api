using System.Data;
using MySql.Data.MySqlClient;
using TDMUMotelWeb.Models;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace TDMUMotelWeb.Data;

public class AccountData
{
    private static AccountData? _instance;
    public static AccountData Instance => _instance ??= new AccountData();
    
    public void AddUser(AccountModel accountModel)
    {
        try
        {
            var connectToMotel = ConfigurationManager.ConnectionStrings["ConnectionStringToMotel"].ConnectionString;
            var mySql = new MySqlConnection(connectToMotel);
            var cmd = new MySqlCommand("add_user");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("i_fullname", accountModel.Fullname);
            cmd.Parameters.AddWithValue("i_username", accountModel.Username);
            cmd.Parameters.AddWithValue("i_email", accountModel.Email);
            cmd.Parameters.AddWithValue("i_address", accountModel.Address);
            cmd.Parameters.AddWithValue("i_phonenumber", accountModel.PhoneNumber);
            cmd.Parameters.AddWithValue("i_avatar", accountModel.Avatar);
            cmd.Connection = mySql;
            mySql.Open();
            cmd.ExecuteNonQuery();
            mySql.Close();
        }
        catch (Exception e)
        {
            throw new Exception($"AccountData => AddUser, Error: {e}");
        }
    }

    public DataTable GetUserInfo(long userId)
    {
        try
        {
            DataTable dtReturn = new();
            var connectToMotel = ConfigurationManager.ConnectionStrings["ConnectionStringToMotel"].ConnectionString;
            var mySql = new MySqlConnection(connectToMotel);
            var cmd = new MySqlCommand("get_user_info");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("i_userid", userId);
            cmd.Connection = mySql;
            var dr = new MySqlDataAdapter(cmd);
            dr.Fill(dtReturn);
            mySql.Close();
            return dtReturn;
        }
        catch (Exception e)
        {
            throw new Exception($"AccountData => GetUserInfo, Error: {e}");
        }
        
    }
}