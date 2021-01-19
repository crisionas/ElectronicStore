using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ES.Domain.Models.User;

namespace ES.BusinessLayer.Interfaces
{
    public interface IUser
    {
        URegisterResponse UserRegister(URegisterData model);

        ULoginResponse UserLogin(ULoginData model);
    }
}
