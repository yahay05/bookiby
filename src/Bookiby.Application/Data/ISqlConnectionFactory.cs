using System.Data;

namespace Bookiby.Application.Data;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}