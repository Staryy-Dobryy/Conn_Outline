using ConnOutlineMessenger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnOutlineMessenger.BuisnessLogic.Services.Interfaces
{
    public interface IAccountService
    {
        Task Register(RegistrationModel model);
    }
}
