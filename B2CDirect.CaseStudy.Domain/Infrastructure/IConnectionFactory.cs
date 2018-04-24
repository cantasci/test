namespace B2CDirect.CaseStudy.Domain.Infrastructure
{
    using System;
    using System.Data;

    public interface IConnectionFactory : IDisposable
    {
        IDbConnection GetConnection { get; }
    }
}
