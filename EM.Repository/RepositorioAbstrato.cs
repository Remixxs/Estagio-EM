using EM.Domain;
using System;
using System.Linq.Expressions;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace EM.Repository
{
    public abstract class RepositorioAbstrato<T> where T : IEntidade
    {
        public abstract void Add(T objeto);
        public abstract void Remove(T objeto);
        public abstract IEnumerable<T> GetAll();
        public abstract void Update(T Objeto);
        public abstract IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
    }
}