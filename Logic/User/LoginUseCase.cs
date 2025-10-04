using System.Threading.Tasks;
using Common.Interfaces;
using Common.Models;

namespace Logic.User;

public class LoginUseCase
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenHandler _tokenHandler;
    private readonly ICrud<AppUser> _userCrud;

    public LoginUseCase(ICrudFactory crudFactory, IPasswordHasher passwordHasher, ITokenHandler tokenHandler)
    {
        _userCrud = crudFactory.GetCrud<AppUser>();
        _passwordHasher = passwordHasher;
        _tokenHandler = tokenHandler;
    }

    public async Task<UseCaseResult<UserResponse>> LoginAsync(LoginRequest request)
    {
        var user = await _userCrud.GetByQueryAsync(u => u.Name == request.Name);
        if (user == null)
            return UseCaseResult<UserResponse>.Failure("User not found");

        if (!_passwordHasher.VerifyPassword(request.Password, user.Password))
            return UseCaseResult<UserResponse>.Failure("Invalid password");

        var token = _tokenHandler.GenerateToken(user);
        var response = new UserResponse
        {
            Id = user.Id,
            Name = user.Name,
            Token = token
        };
        return UseCaseResult<UserResponse>.Success(response);
    }
}