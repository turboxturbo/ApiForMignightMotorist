using ApiForMignightMotorist.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ApiForMignightMotorist.Interfaces
{
    public interface IMotoristService
    {
        Task<IActionResult> Authorization(Auth auth);
    }
}
