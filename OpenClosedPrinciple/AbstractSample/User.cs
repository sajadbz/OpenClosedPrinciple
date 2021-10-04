using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrinciple.AbstractSample
{
    public enum UserType
    {
        Gold, Silver
    }
    public abstract class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        //public UserType UserType { get; set; }

        protected User(int id, string name, decimal salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }

        public abstract decimal CalculateBonus();

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Bonus : {CalculateBonus()}";
        }
    }
    public class GoldUser : User
    {
        public GoldUser(int id, string name, decimal salary) : base(id, name, salary)
        {
        }

        public override decimal CalculateBonus()
        {
            return Salary * .1M;
        }
    }

    public class SilverUser : User
    {
        public SilverUser(int id, string name, decimal salary) : base(id, name, salary)
        {
        }

        public override decimal CalculateBonus()
        {
            return Salary * .05M;
        }
    }
}
