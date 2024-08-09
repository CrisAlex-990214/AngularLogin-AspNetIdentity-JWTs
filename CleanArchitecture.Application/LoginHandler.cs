using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Application
{
    public class LoginRequest : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginHandler(UserManager<User> userManager, IJwtService jwtService,
        SignInManager<User> signInManager) : IRequestHandler<LoginRequest, string>
    {
        private readonly UserManager<User> userManager = userManager;
        private readonly IJwtService jwtService = jwtService;
        private readonly SignInManager<User> signInManager = signInManager;

        public async Task<string> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);

            var result = await signInManager.PasswordSignInAsync(user, request.Password, false, false);

            return result.Succeeded ? jwtService.GenerateToken(user) : null;
        }
    }
}
