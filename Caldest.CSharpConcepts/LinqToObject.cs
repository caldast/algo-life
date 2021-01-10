using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caldest.CSharpConcepts
{
    public class State
    {
        public string Name { get; set; }
        public string City { get; set; }
        
        public string TwoLetterCode { get; set; }
    }

    class Person
    {
        public String ZipCode, Gender, Name;
    }

    

    class LinqToObject
    {
        private IEnumerable<string> _abbs = new string[] { "MN", "CA", "NY", "WA", "MT" };

        private IEnumerable<State> _usStates = new State[]
        {
            new State{ City = "Saint Paul", Name = "Minnesota",  TwoLetterCode = "MN" },
            new State{ City = "San Fransisco", Name = "California",  TwoLetterCode = "CA"},
            new State{ City = "Spokane", Name = "Washington",  TwoLetterCode = "WA"},
            new State{ City = "New York", Name = "New York"},
            new State{ City = "Helena", Name = "Montana"},
            new State{ City = "Orlando", Name = "Florida"},
            new State{ City = "Minneapolis", Name = "Minnesota"},
            new State{ City = "Seattle", Name = "Washington"},

        };

        public void Join()
        {
            var query = from state in _usStates
                        join abb in _abbs on state.TwoLetterCode equals abb
                        select state;

            var query1 = _usStates.Join(_abbs, s => s.TwoLetterCode, a => a, 
                (s, a) => s);
        }

        public IEnumerable<State> GetAllStates(string startsWith)
        {
          return  _usStates.Where(s => s.Name.StartsWith(startsWith));
        }
        public IEnumerable<string> GetStatesAndRespectiveWA()
        {

            return _usStates.Select(s=>s.Name).Zip(_abbs, Concat);
        }

        public IEnumerable<State> SortStatesByDescending()
        {
            return _usStates.OrderByDescending(s => s.Name);
        }

        public void GroupBy()
        {
            // Group by name
            var query = from s in _usStates                    
                        group s by s.Name;

            IterateGroup(query);

            // fluent expression

            var fluent = _usStates.GroupBy(s => s.Name);

            IterateGroup(query);

            //group by county first and then 

        }

        public void GroupByAdvanced()
        {
            //https://stackoverflow.com/questions/39001256/nested-groupby-linq-using-fluent-syntax?rq=1

            var people = new List<Person>
            {
                new Person { ZipCode= "11111", Gender = "M", Name = "Tom" },
                new Person { ZipCode= "11111", Gender = "M", Name = "Bob" },
                new Person { ZipCode= "11111", Gender = "F", Name = "Nancy" },
                new Person { ZipCode= "11111", Gender = "F", Name = "Lisa" },
                new Person { ZipCode= "22222", Gender = "M", Name = "Dan" },
                new Person { ZipCode= "33333", Gender = "F", Name = "Mary" },
                new Person { ZipCode= "44444", Gender = "F", Name = "Joan" },
                new Person { ZipCode= "44444", Gender = "F", Name = "Jane" },
                new Person { ZipCode= "44444", Gender = "M", Name = "Bill" }
            };

            //group by zipcode and within zipcode by gender            

            var byZipCodeQuery = people.GroupBy(p => p.ZipCode)
                                        .GroupBy(
                                                keySelector: z => z.Key,
                                                elementSelector: z => z.GroupBy(g => g.Gender)
                                            );

            foreach (IGrouping<string,IEnumerable<IGrouping<string,Person>>> byzipCode in byZipCodeQuery)
            {
                Console.WriteLine(byzipCode.Key);

                foreach (IEnumerable<IGrouping<string,Person>> byGender in byzipCode)
                {
                    foreach (IGrouping<string,Person> g in byGender)
                    {
                        Console.WriteLine(g.Key);
                        foreach (Person p in g)
                            Console.WriteLine(p.Name);
                    }
                }
            }

            // Another approach

            //SelectMany flattens out 
            IEnumerable<IGrouping<string,IGrouping<string,Person>>>  byZipCodeQuery1 
                = people.GroupBy(p => p.ZipCode)
                        .SelectMany(p=>p.GroupBy(g=>g.Gender).GroupBy(g=>g.Key));


            foreach (IGrouping<string, IGrouping<string, Person>> byZip in byZipCodeQuery1)
            {
                Console.Write(byZip.Key); //zip 
                foreach (IGrouping<string, Person> byGender in byZip)
                {
                    Console.Write(byGender.Key); // gender
                    foreach (Person p in byGender)
                    {
                        Console.Write(p.Name);
                        Console.Write(p.ZipCode);
                    }
                }
            }

        }


        private void IterateGroup(IEnumerable<IGrouping<string,State>> query)
        {
            foreach (var kv in query)
            {
                Console.WriteLine(kv.Key);
                foreach (var y in kv)
                {
                    Console.WriteLine(y.Name);
                    Console.WriteLine(y.City);
                }
            }
        }

        public string Concat(string first, string second)
        {
            return $"{first}: {second}";
        }

    }
}
