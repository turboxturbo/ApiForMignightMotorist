using ApiForMignightMotorist.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ApiForMignightMotorist.Interfaces
{
    public interface IMotoristService
    {
        Task<IActionResult> Authorization(Auth auth);
        Task<IActionResult> SignUp(RegReq regReq);
        Task<IActionResult> GetUserInfo(CurrentUser info);
        Task<IActionResult> GetAllScins();
        Task<IActionResult> GetMyScins(CurrentUser currentUser);
        Task<IActionResult> BuyScin(BuyScin buyScin);
        Task<IActionResult> SelectScin(CurrentScin currentScin);
        Task<IActionResult> AddWin(CurrentUser currentuser);
    }
}
