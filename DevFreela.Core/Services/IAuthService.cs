using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Services
{
    public interface IAuthService
    {
        string GenerateJewToken(string email, string role);
        //role representa o papel do usuário: cliente ou freelancer
    }
}
