﻿using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Flats.Api.Models;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Flats.BusinessLogic.UsereBusiness;
using Flats.BusinessLogic.ProfileBusiness;

namespace Flats.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GenerateJWTTokenController : ApiController
    {
        private ApplicationUserManager _userManager;
        private readonly IUsereBusiness _usereBusiness;
        private readonly IProfileBusiness _profileBusiness;
        public GenerateJWTTokenController()
        {
            _usereBusiness = new UsereBusiness();
            _profileBusiness = new ProfileBusiness();
        }

        public GenerateJWTTokenController(ApplicationUserManager userManager)
        {         
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> Authenticate(UserRequest user)
        {
            var userResponse = new UserResponse { };
            UserRequest userRequest = new UserRequest { };
            userRequest.Username = user.Username.ToLower();
            userRequest.Password = user.Password;
            IHttpActionResult response;
            var result = await UserManager.FindAsync(user.Username, user.Password);
            //if credentials are valid
            if (result != null)
            {
                string token = createToken(userRequest.Username);
                //return the token
                return Ok<object>(new { token = token,User= _profileBusiness.GetFullProfileByUserId(new Guid(result.Id)) });
            }
            else
            {
                // if credentials are not valid send unauthorized status code in response
                userResponse.responseMsg.StatusCode = HttpStatusCode.Unauthorized;
                response = ResponseMessage(userResponse.responseMsg);
                return response;
            }
        }
        private string createToken(string username)
        {
            //Set issued at date
            DateTime issuedAt = DateTime.UtcNow;
            //set the time when it expires
            DateTime expires = DateTime.UtcNow.AddDays(7);

            //http://stackoverflow.com/questions/18223868/how-to-encrypt-jwt-security-token
            var tokenHandler = new JwtSecurityTokenHandler();

            //create a identity and add claims to the user which we want to log in
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username)
            });

            const string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
            var now = DateTime.UtcNow;
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);


            //create the jwt
            var token =
                (JwtSecurityToken)
                    tokenHandler.CreateJwtSecurityToken(
                        issuer: "http://localhost:50191",
                        audience: "http://localhost:50191",
                        subject: claimsIdentity,
                        notBefore: issuedAt,
                        expires: expires,
                        signingCredentials: signingCredentials
                        );
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}