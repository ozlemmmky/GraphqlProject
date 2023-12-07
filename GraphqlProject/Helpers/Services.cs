

using Microsoft.EntityFrameworkCore;

namespace GraphqlProject.Helpers

{
    public static class Services
    {
        public static void AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<GraphqlDbContext>(options => options.UseSqlServer("Server=DESKTOP-6GC45A8\\SQLEXPRESS;Database=GraphqlDatabase1;uid=ozlem;pwd=123;Trusted_Connection=True;TrustServerCertificate=True"));
        }
    }
}
