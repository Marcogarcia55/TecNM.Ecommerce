using System.Data.Common;

namespace TecNM.Ecommrce.Api.DataAcces.Interfaces;

public interface IDbContext
{
    DbConnection Connection { get; }
}