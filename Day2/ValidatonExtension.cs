using FluentValidation;

namespace Day2
{
    public static class ValidatonExtension
    {
        public static IServiceCollection RegisterValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<BookDTO>();
            return services;
        }
    }
}
