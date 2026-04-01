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

        [HttpGet]
        [Route("auth")]
        public async Task<IActionResult> Authorization(Auth auth)
        {
            return await _motoristService.Authorization(auth);
        }
    }
}
