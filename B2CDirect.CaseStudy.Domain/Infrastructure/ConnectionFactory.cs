namespace B2CDirect.CaseStudy.Domain.Infrastructure
{
    using System;
    using System.Data; 

    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string connectionString;

        public ConnectionFactory(string connectionString){
            this.connectionString = connectionString;
        }
 
        public IDbConnection GetConnection
        {
            get
            {
                var conn = new Microsoft.Data.Sqlite.SqliteConnection
                
                {
                    ConnectionString = connectionString
                };
                conn.Open();
                return conn;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                } 

                disposedValue = true;
            }
        }


        ~ConnectionFactory() { 
          Dispose(false);
        }
 

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
