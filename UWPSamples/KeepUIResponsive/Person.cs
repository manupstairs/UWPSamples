using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepUIResponsive
{
    public class Person
    {
        public int Age { get; set; }

        public string Name { get; set; }

        private Person()
        {

        }

        public static Person CreatePreson(int age, string name)
        {
            var person = new Person
            {
                Age = age,
                Name = name
            };
            Task.Delay(500).Wait();
            return person;
        }

        public static async Task<Person> CreatePresonAsync(int age, string name)
        {
            var person = new Person
            {
                Age = age,
                Name = name
            };
            await Task.Delay(500);
            return person;
        }
    }
}
