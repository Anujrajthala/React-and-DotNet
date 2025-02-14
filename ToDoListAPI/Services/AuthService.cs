using System.Security.Claims;
using AutoMapper;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListAPI.Data;
using ToDoListAPI.DTOs;
using ToDoListAPI.Models;
using Microsoft.IdentityModel.Tokens;

public class AuthService{

    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthService(UserManager<ApplicationUser> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager){
        _userManager = userManager;
        _configuration = configuration;
        _roleManager = roleManager;
    }

    public async Task<string> Register(RegisterDTO dto, string role = "User"){
        var user = _mapper.Map<ApplicationUser>(dto);
        var result  = await _userManager.CreateAsync(user,dto.Password);
        if(!result.Succeeded) return null;
        if(await _roleManager.RoleExistsAsync(role)) await _userManager.AddToRoleAsync(user,role);
        return GenerateJwtToken(user);

    }
    public async Task<string> Login(LoginDTO dto){
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if(user== null || !await _userManager.CheckPasswordAsync(user,dto.Password)) return null;
        return GenerateJwtToken(user);
    }

    private string GenerateJwtToken(ApplicationUser user){
        var tokenHandler = new JwtSecurityTokenHandler();
        var key  = Encoding.UTF8.GetBytes(_configuration["Jwt: Secret"]);
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, GetUserRole(user))

        };
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        );
        return tokenHandler.WriteToken(token);
    }

    private string GetUserRole(ApplicationUser user){
        var roles = _userManager.GetRolesAsync(user).Result;
        return roles.FirstOrDefault()?? "User";
    }

}