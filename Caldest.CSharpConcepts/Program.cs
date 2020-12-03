using Caldest.CSharpConcepts.LinqToSql;
using System;
using System.Reflection;

namespace Caldest.CSharpConcepts
{

    class Program
    {
        static void Main(string[] args)
        {
            //var linqToObj = new LinqToObject();
            //linqToObj.GroupByAdvanced();

            //var linqToSql = new LinqToSqlRepo();
            //linqToSql.PrintAllCoursesAndAssociatedTeacher();

            //TestVehicleEquality();

            ReflectUpon(typeof(LinqToObject));

        }
        public static void ReflectUpon(Type t1)
        {
            string name1 = t1.FullName;

           
            foreach (PropertyInfo p in t1.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
            {
                Console.WriteLine(p.Attributes);
            }

            foreach (MethodInfo method in t1.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
            {
                Console.Write(method.Name);
                var param = method.GetParameters();
                Console.Write(method.ReturnType);
            }


        }


        public static void TestVehicleEquality()
        {

            var vehicle1 = new Vehicle()
            {
                VIN = "12345",
                Name = "Honda",
                Make = "Honda Civic 2012"
            };

            var vehicle2 = new Vehicle()
            {
                VIN = "123456",
                Name = "Honda",
                Make = "Honda Civic 2012"
            };

            bool areEqual = vehicle1.Equals(vehicle2);

        }
    }

    
    public class Vehicle: IEquatable<Vehicle>
    {
        public string VIN { get; set; }
        public string Name { get; set; }
        public string Make { get; set; }

        public bool Equals(Vehicle other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (other.GetType() != this.GetType())
                return false;

            return string.Equals(Name, other.Name)
                && string.Equals(Make, other.Make);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Vehicle);
        }

        public override int GetHashCode()
        {
            return VIN.GetHashCode();
        }
    }
}
