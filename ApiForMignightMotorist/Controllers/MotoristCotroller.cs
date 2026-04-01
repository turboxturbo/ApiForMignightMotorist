using ApiForMignightMotorist.Interfaces;
using ApiForMignightMotorist.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace ApiForMignightMotorist.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class MotoristCotroller
    {
        private readonly IMotoristService _motoristService;

        public MotoristCotroller(IMotoristService motoristService)
        {
            _motoristService = motoristService;
        }

        [HttpPost]
        [Route("auth")]
        public async Task<IActionResult> Authorization(Auth auth)
        {
            return await _motoristService.Authorization(auth);
        }
        [HttpPost]
        [Route("reg")]
        public async Task<IActionResult> SignUp(RegReq regReq)
        {
            return await _motoristService.SignUp(regReq);
        }
        [HttpPost]
        [Route("getinfo")]
        public async Task<IActionResult> GetUserInfo(CurrentUser info)
        {
            return await _motoristService.GetUserInfo(info);
        }
        [HttpGet]
        [Route("allscins")]
        public async Task<IActionResult> GetAllScins()
        {
            return await _motoristService.GetAllScins();
        }
        [HttpPost]
        [Route("myscins")]
        public async Task<IActionResult> GetMyScins(CurrentUser currentUser)
        {
            return await _motoristService.GetMyScins(currentUser);
        }
        [HttpPost]
        [Route("buyscin")]
        public async Task<IActionResult> BuyScin(BuyScin buyScin)
        {
            return await _motoristService.BuyScin(buyScin);
        }
        [HttpPost]
        [Route("selectscin")]
        public async Task<IActionResult> SelectScin(CurrentScin currentScin)
        {
            return await _motoristService.SelectScin(currentScin);
        }
    }
}
