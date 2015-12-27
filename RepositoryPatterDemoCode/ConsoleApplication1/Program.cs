using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var testRepository = new TestRepository<Car>(new RepositoryPaterrnTestContext()))
            {
                var result = testRepository.GetById(1);
                Console.WriteLine(result.Model + " " + result.Brand);
            }

            using (var testRepository = new TestRepository<Person>(new RepositoryPaterrnTestContext()))
            {
                var result = testRepository.GetById(2);
                Console.WriteLine(result.Name + " " + result.Surname);
            }

            using (var testRepository = new TestRepository<Car>(new RepositoryPaterrnTestContext()))
            {
                var car = new Car();
                car.Brand = "BMC Fatih";
                car.Model = 1992;
                testRepository.Insert(car);
            }

            using (var testRepository = new TestRepository<Person>(new RepositoryPaterrnTestContext()))
            {
                var person = new Person();
                person.Name = "Küfürbaz";
                person.Surname = "Haydo";
                testRepository.Insert(person);
            }

            using (var testRepository = new TestRepository<Car>(new RepositoryPaterrnTestContext()))
            {
                var result = testRepository.GetByMyQuery(c => c.Brand.Equals("BMW"));
                Console.WriteLine(result.Brand + " " + result.Model);
            }

            Console.ReadLine();
        }
    }
}
