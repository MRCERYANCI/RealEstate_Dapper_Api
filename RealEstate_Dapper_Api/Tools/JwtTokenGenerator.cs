﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RealEstate_Dapper_Api.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel getCheckAppUserViewModel)
        {
            var claims = new List<Claim>();

            if (!string.IsNullOrWhiteSpace(getCheckAppUserViewModel.Role))
            {
                claims.Add(new Claim(ClaimTypes.Role,getCheckAppUserViewModel.Role));
            }

            claims.Add(new Claim(ClaimTypes.NameIdentifier, getCheckAppUserViewModel.Id.ToString()));

            if (!string.IsNullOrWhiteSpace(getCheckAppUserViewModel.UserName))
            {
                claims.Add(new Claim("UserName", getCheckAppUserViewModel.UserName));
            }

            if (!string.IsNullOrWhiteSpace(getCheckAppUserViewModel.Email))
            {
                claims.Add(new Claim("Email", getCheckAppUserViewModel.Email));
            }

            if (!string.IsNullOrWhiteSpace(getCheckAppUserViewModel.PhoneNumber))
            {
                claims.Add(new Claim("PhoneNumber", getCheckAppUserViewModel.PhoneNumber));
            }

            if (!string.IsNullOrWhiteSpace(getCheckAppUserViewModel.TC))
            {
                claims.Add(new Claim("TC", getCheckAppUserViewModel.TC));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
            var signinCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiredate = DateTime.UtcNow.AddMinutes(JwtTokenDefaults.Expire);
            JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidIssuer, audience: JwtTokenDefaults.ValidAudiance, claims: claims, notBefore: DateTime.UtcNow, expires: expiredate, signingCredentials: signinCredentials);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return new TokenResponseViewModel(tokenHandler.WriteToken(token), expiredate);
        }
    }
}