using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using TDMUMotelWeb.Data;
using TDMUMotelWeb.Models;
using TDMUMotelWeb.Repositories;

namespace TDMUMotelWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController: Controller
{
    [Route("Register")]
    [HttpPost]
    public ActionResult Register(AccountModel accountModel)
    {
        try
        {
            AccountRepository.Instance.AddUser(accountModel);
            return Json(new { message = "Thêm tài khoản thành công." });
        }
        catch (Exception e)
        {
            if (e.Message.Contains("[+"))
                return Conflict(new { message = new Regex(@"\[\+(.*)\+\]").Matches(e.ToString())[0].Groups[1].Value });
            return BadRequest(new { message = $"Account => Register, Error: {e}" });
        }
    }

    [Route("GetUserInfo")]
    [HttpGet]
    public ActionResult GetUserInfo(long userId)
    {
        try
        {
            return Json(new { message = "Thành công.", data = AccountRepository.Instance.GetUserInfo(userId) });
        }
        catch (Exception e)
        {
            return BadRequest(new { message = $"Account => GetUserInfo, Error: {e}" });
        }
    }
}