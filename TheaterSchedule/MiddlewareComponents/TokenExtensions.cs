using Microsoft.AspNetCore.Builder;

namespace TheaterSchedule.MiddlewareComponents
{
    public static class TokenExtensions
    {
        public static IApplicationBuilder UseToken(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
