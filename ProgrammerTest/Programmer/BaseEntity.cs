using Programmer.DataRepository;
using System;

namespace Programmer
{
    public abstract class BaseEntity<T> where T : class
    {
        public string Id { get; set; }

        protected static IRepository Repository;
        public BaseEntity()
        {
            Repository = new FileRepository();
        }
        public BaseEntity(IRepository repository)
        {
            Repository = repository ?? new FileRepository();
        }
        public static T Find(string id)
        {
            return Repository.Find<T>(id);
        }
        public virtual void Save()
        {
            this.Id = Guid.NewGuid().ToString();
            Repository.Save(this);
        }

        public virtual void Delete()
        {
            if (!string.IsNullOrEmpty(this.Id))
            {
                Repository.Delete(this.Id);
                this.Id = null;
            }
        }
    }


}
