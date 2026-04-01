using ApiForMignightMotorist.DataBaseContext;
using ApiForMignightMotorist.Interfaces;
using ApiForMignightMotorist.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiForMignightMotorist.Services
{
    public class MotoristService : IMotoristService
    {
        private readonly ContextDb _context;
        public MotoristService(ContextDb context)
        {
            _context = context;
        }

        public async Task<IActionResult> Authorization(Auth auth)
        {
            var login = await _context.Logins.FirstOrDefaultAsync(l => l.Login == auth.Login && l.Password == auth.Password);
            if (login == null)
            {
                return new NotFoundObjectResult(new { status = false });
            }
            return new OkObjectResult(new { status = true });
        }
    }
}
