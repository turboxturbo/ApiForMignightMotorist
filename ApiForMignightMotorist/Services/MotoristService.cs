using ApiForMignightMotorist.DataBaseContext;
using ApiForMignightMotorist.Interfaces;
using ApiForMignightMotorist.Models;
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
                return new OkObjectResult(new { status = false });
            }
            return new OkObjectResult(new { status = true, iduser = login.IdUser });
        }
        public async Task<IActionResult> SignUp(RegReq regReq)
        {
            var login = await _context.Logins.FirstOrDefaultAsync(l => l.Login == regReq.Login);
            if (login != null)
            {
                return new OkObjectResult(new { status = false, message = "Login already exists" });
            }
            var user = new Users
            {
                UserName = regReq.Username,
                Coins = 0,
                SelectedScin = "Scin1"
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            var newLogin = new Logins
            {
                Login = regReq.Login,
                Password = regReq.Password,
                IdUser = user.IdUser
            };
            await _context.Logins.AddAsync(newLogin);
            await _context.SaveChangesAsync();
            var newuserscin = new UserScins
            {
                IdScin = 1,
                IdUser = user.IdUser
            };
            await _context.UserScins.AddAsync(newuserscin);
            await _context.SaveChangesAsync();

            return new OkObjectResult(new { status = true });
        }
        public async Task<IActionResult> GetUserInfo(CurrentUser currentuser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.IdUser == currentuser.IdUser);
            var userscins = await _context.UserScins.Where(us => us.IdUser == currentuser.IdUser).Include(s => s.Scins).ToListAsync();
            if (user == null || userscins == null || userscins.Count == 0)
            {
                return new OkObjectResult(new { status = false });
            }
            return new OkObjectResult(new { status = true, userName = user.UserName, coins = user.Coins, selectedScin = user.SelectedScin, userscins = userscins });
        }
        public async Task<IActionResult> GetAllScins()
        {
            var scins = await _context.Scins.ToListAsync();
            if (scins == null || scins.Count == 0)
            {
                return new OkObjectResult(new { status = false });
            }
            return new OkObjectResult(new { status = true, scins = scins });
        }
        public async Task<IActionResult> BuyScin(BuyScin buyScin)
        {
            var scin = await _context.Scins.FirstOrDefaultAsync(s => s.NameScin == buyScin.NameScin);
            var user = await _context.Users.FirstOrDefaultAsync(u => u.IdUser == buyScin.IdUser);
            if (scin == null || user == null)
            {
                return new OkObjectResult(new { status = false });
            }
            if (user.Coins < scin.Coins)
            {
                return new OkObjectResult(new { status = false, message = "Not enough coins" });
            }
            user.Coins -= scin.Coins;
            _context.Users.Update(user);
            var userScin = new UserScins
            {
                IdUser = user.IdUser,
                IdScin = scin.IdScin
            };
            await _context.UserScins.AddAsync(userScin);
            await _context.SaveChangesAsync();
            return new OkObjectResult(new { status = true });
        }

        public async Task<IActionResult> GetMyScins(CurrentUser currentUser)
        {
            var scins = await _context.UserScins.Where(s => s.IdUser == currentUser.IdUser).ToListAsync();
            if (scins.Count == 0 || scins == null)
            {
                return new OkObjectResult(new { status = false });
            }
            return new OkObjectResult(new { status = true, scins = scins });
        }
        public async Task<IActionResult> SelectScin(CurrentScin currentScin)
        {
            var scin = await _context.Scins.FirstOrDefaultAsync(s => s.NameScin == currentScin.NameScin);
            var user = await _context.Users.FirstOrDefaultAsync(u => u.IdUser == currentScin.IdUser);
            if (scin == null || user == null)
            {
                return new OkObjectResult(new { status = false });
            }
            var userscin = await _context.UserScins.FirstOrDefaultAsync(s => s.IdScin == scin.IdScin && s.IdUser == currentScin.IdUser);
            if (userscin == null)
            {
                return new OkObjectResult(new { status = false });
            }

            user.SelectedScin = currentScin.NameScin;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return new OkObjectResult(new { status = true });

        }

    }
}