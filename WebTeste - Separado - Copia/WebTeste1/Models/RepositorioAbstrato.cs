using System.Linq.Expressions;

namespace WebTeste
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