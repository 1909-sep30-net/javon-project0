using Microsoft.EntityFrameworkCore;
using Project0.DataAccess.Entities;

namespace Project0.DataAccess
{
    /// <summary>
    /// Holds the options for the DBContext.
    /// </summary>
    internal class SQLOptions
    {
        public static DbContextOptions<TThreeTeasContext> options = new DbContextOptionsBuilder<TThreeTeasContext>()
            .UseSqlServer(SecretConfiguration.ConnectionString)
            .UseLoggerFactory(SQLLogger.AppLoggerFactory)
            .Options;
    }
}
