using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
