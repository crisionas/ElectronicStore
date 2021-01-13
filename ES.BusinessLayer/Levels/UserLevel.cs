using System;
using System.Collections.Generic;
using System.Text;
using ES.BusinessLayer.Implementation;
using ES.BusinessLayer.Interfaces;
using ES.Domain.Models;

namespace ES.BusinessLayer.Levels
{
    public class UserLevel : UserImplementation, IUser
    {
        public URegisterResponse UserRegister(URegisterData model)
        {
            return RegistrationAction(model);
        }
    }
}
