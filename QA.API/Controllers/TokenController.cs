using QA.API.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;


namespace QA.API.Controllers
{
    public class TokenController : ApiController
    {
        private QADbEntities db = new QADbEntities();


        [AllowAnonymous]
        [Route("api/Token/GetToken/{username}/{password}")]
        public string Get(string username, string password)
        {
            if (CheckUser(username, password))
            {
                return JwtManager.GenerateToken(username);
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        public bool CheckUser(string username, string password)
        {
            Users user = db.Users.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
            if (user != null)
                return true;
            return false;
        }
    }
}
