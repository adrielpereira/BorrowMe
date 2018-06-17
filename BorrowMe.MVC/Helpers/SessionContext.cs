using BorrowMe.Domain.Entities;
using BorrowMe.MVC.ViewModels;
using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace BorrowMe.MVC.Utils
{
    public class SessionContext
    {
        public void SetAuthenticationToken(string name, bool isPersistant, UserAuthViewModel userData)
        {
            string data = null;
            if (userData != null)
            {
                data = new JavaScriptSerializer().Serialize(userData);
            }
                

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, name, DateTime.Now, DateTime.Now.AddYears(1), isPersistant, data);

            string cookieData = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieData)
            {
                HttpOnly = true,
                Expires = ticket.Expiration
            };

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public UserAuthViewModel GetUserData()
        {
            UserAuthViewModel userData = null;

            HttpCookie cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);

                userData = new JavaScriptSerializer().Deserialize(ticket.UserData, typeof(UserAuthViewModel)) as UserAuthViewModel;
            }

            return userData;
        }
    }
}