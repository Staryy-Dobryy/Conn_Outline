using ConnOutlineMessenger.BuisnessLogic.Interfaces;
using ConnOutlineMessenger.BuisnessLogic.Tools;
using ConnOutlineMessenger.DataAccess.Interfaces;
using ConnOutlineMessenger.Entities;
using ConnOutlineMessenger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnOutlineMessenger.BuisnessLogic.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task Register(RegistrationModel model)
        {
            var user = await _userRepository.GetByEmailAsync(model.Email);
            if (user == null)
            {
                var newUser = new User()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Password = HashPasswordTool.HashPassword(model.Password),
                    RegDateTime = DateTime.Now
                };
                try
                {
                    await _userRepository.CreateAsync(newUser);
                }
                finally
                {
                    _userRepository.Dispose();
                }
            }
        }
    }
}
