using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Ord.EF.Data;

public class OrdOracleContextFactory : IDesignTimeDbContextFactory<OrdOracleContext>
{
    public OrdOracleContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<OrdOracleContext>();
        optionsBuilder.UseOracle("User Id=UD_Phillipm;Password=UD_PHILLIPM;Data Source=54.198.204.133:1521/FREEPDB1");

        return new OrdOracleContext(optionsBuilder.Options);
    }
}