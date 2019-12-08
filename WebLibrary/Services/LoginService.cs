using Binding;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public interface ILoginService
    {
        Response InsertReader(Registration Reg);
        Response ReaderLogin(Login login);
    }
    public class LoginService : ILoginService
    {
        public readonly LibraryDBContext _bookDbContext;
        public LoginService(LibraryDBContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }
        public Response InsertReader(Registration Reg)
        {
            try
            {
                Registration RG = new Registration();
                if (RG.Id == 0)
                {

                    RG.UserName = Reg.UserName;
                    RG.Email = Reg.Email;
                    RG.Password = Reg.Password;
                    RG.City = Reg.City;
                    _bookDbContext.dataRegUser.Add(RG);
                    _bookDbContext.SaveChanges();
                    return new Response
                    { Status = "Success", Message = "Your account saved" };
                }
            }
            catch (Exception)
            {
                throw;
            }
            return new Response
            { Status = "Error", Message = "Не сохранено. Проверьте данные" };
        }
        public Response ReaderLogin(Login login)
        {
            var log = _bookDbContext.dataRegUser.Where(x => x.Email.Equals(login.Email) && x.Password.Equals(login.Pass)).FirstOrDefault();
            if (log == null)
            {
                return new Response { Status = "Invalid", Message = "Пользователь не зарегестрирован" };
            }
            else
                return new Response { Status = "Success", Message = "Enter Successfully" };
        }
    }

}
