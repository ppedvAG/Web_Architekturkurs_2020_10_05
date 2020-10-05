using System;
using System.Collections.Generic;

namespace _004_Interface_Segregation_principle_ISP
{

    #region Bad Sample

    public interface BadIReadOnlyRepository<T>
    {
        List<T> ReadAll();
        T GetById();
    }

    public interface BadIRepository<T> : BadIReadOnlyRepository<T>
    {
        public void Write(T ToWrite);
        public void Update(T Orginal, T Modified);
        public void Delete(T ToDelete);
    }

    public class BadRepository<T> : BadIRepository<T>
    {
        public void Delete(T ToDelete)
        {
            throw new NotImplementedException();
        }

        public T GetById()
        {
            throw new NotImplementedException();
        }

        public List<T> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(T Orginal, T Modified)
        {
            throw new NotImplementedException();
        }

        public void Write(T ToWrite)
        {
            throw new NotImplementedException();
        }
    }
    #endregion




    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    public interface ICanRead<T>
    {
        List<T> ReadAll();
        T GetById();
    }

    public interface ICanWrite<T>
    {
        public void Write(T ToWrite);
        
    }

    public interface ICanUpdate<T>
    {
        public void Update(T ToUpdate);
    }

    public interface ICanDelete<T>
    {
        public void Delete(T ToDelete);
    }

    public class Repository<T> : ICanRead<T>, ICanWrite<T>, ICanUpdate<T>, ICanDelete<T>
    {
        public void Delete(T ToDelete)
        {
            throw new NotImplementedException();
        }

        public T GetById()
        {
            throw new NotImplementedException();
        }

        public List<T> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(T ToUpdate)
        {
            throw new NotImplementedException();
        }

        public void Write(T ToWrite)
        {
            throw new NotImplementedException();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            #region BAd Code Implementierung
            //Bei nur Leserechten
            BadIReadOnlyRepository<Employee> readOnlyRepository = new BadRepository<Employee>();

            //Bei Schreib und Leserechte
            BadIRepository<Employee> repository = new BadRepository<Employee>();
            #endregion




            //bessere Variante

            ICanWrite<Employee> writeRepository = new Repository<Employee>();

            ICanDelete<Employee> deleteRepository = new Repository<Employee>();
        }
    }




}
