using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ES.BusinessLayer.DBModels;
using ES.Domain.Entities;
using ES.Domain.Models;
using ES.Helpers;

namespace ES.BusinessLayer.Implementation
{
    public class UserImplementation
    {
        internal URegisterResponse RegistrationAction(URegisterData model)
        {
            using (var db = new UserContext())
            {
                var user = db.Users.FirstOrDefault(m => m.Email == model.Email);
                if (user != null)
                {
                    return new URegisterResponse
                    {
                        Status = false,
                        Message = "This username exists."
                    };
                }
                else
                {
                    var userdet = new Users();
                    userdet.Name = model.Name;
                    userdet.Email = model.Email;
                    userdet.Password = LoginHelper.HashGen(model.Password);
                    userdet.Birth_Date = DateTime.Parse(model.Birth_date);
                    userdet.LastIp = model.IP;
                    userdet.RegisterDateTime = model.RegisteDateTime;
                    userdet.LastLogin = DateTime.Now;
                    db.Users.Add(userdet);
                    db.SaveChanges();
                    return new URegisterResponse{ Status = true };
                }
            }

            return new URegisterResponse {Status = false, Message = "????"};
        }
    }
}

