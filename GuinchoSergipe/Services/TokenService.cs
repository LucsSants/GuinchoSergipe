using GuinchoSergipe.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GuinchoSergipe.Services;

public class TokenService
{
    private UserManager<UserModel> _userManager;

    public TokenService(UserManager<UserModel> userManager)
    {
        _userManager = userManager;
    }

    public async Task<string> GenerateToken(UserModel usuario)
    {
        var claims = await _userManager.GetClaimsAsync(usuario);
        var roles = await _userManager.GetRolesAsync(usuario);

        foreach (var role in roles)
        {
            Console.Write(role.ToString());
        }

        claims.Add(new Claim("Email", usuario.Email));
        claims.Add(new Claim("Id", usuario.Id));

        foreach ( var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
        }

        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sdkfbsdjkhfgdsifgsdilxg3548164984adakjhdgakhd"));

        var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
              expires: DateTime.UtcNow.AddMinutes(10),
              claims: claims,
              signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);

    }
}