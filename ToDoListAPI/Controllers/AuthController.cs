using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoListAPI.DTOs;
using ToDoListAPI.Services;


[Route("api/auth")]
[ApiController]
public class AuthController: ControllerBase{
    private readonly AuthService _authService;
    public AuthController(AuthService authService){
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDTO dto){
        var token  = await _authService.Register(dto);
        if(token== null) return BadRequest("Registration failed.");
        return Ok(new{Token = token});
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO dto){
        var token  = await _authService.Login(dto);
        if(token==null) return BadRequest("Login Failed..");
        return Ok(new{Token= token});
    }
}