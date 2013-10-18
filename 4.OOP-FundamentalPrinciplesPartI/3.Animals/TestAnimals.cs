using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.Animals
{
    class TestAnimals
    {
        static void Main()
        {
            Dog[] dogs = new Dog[]
            {
                new Dog("Sharo", 1,"male", "German Shepherd"),
                new Dog("Mecho", 4, "male", "Pug"),
                new Dog("Bobi", 2, "male", "Pinscher")
            };
            Cat[] cats = new Cat[]
            {
                new Cat("Moni", 6, "female", "Persian"),
                new Cat("Topcho", 1, "male", "hibrid"),
                new Cat("Bobcho", 3, "male", "American Curl")
            };
            Kitten[] kittens = new Kitten[]
            {
                new Kitten("Mimi", 2, "female", "Asian Semi-longhair"),
                new Kitten("Anitka", 3, "female", "Bombai"),
                new Kitten("Moli", 1, "female", "Nebelung")
            };
            Tomcat[] tomcats = new Tomcat[]
            {
                new Tomcat("Tomi", 3, "male", "Munchkin"),
                new Tomcat("Domcho", 7, "male", "Persian"),
                new Tomcat("Tobi", 1, "male", "Ragamuffin")
            };
            Frog[] frogs = new Frog[]
            {
                new Frog("Kvakcho", 1, "male", 3),
                new Frog("Jufi", 2, "male", 2),
                new Frog("Timi", 1, "male", 3)
            };
            Console.WriteLine("Average age of the dogs: {0}", Animal.AverageAge(dogs));
            Console.WriteLine("Average age of the cats: {0}", Animal.AverageAge(cats));
            Console.WriteLine("Average age of the kittens: {0}", Animal.AverageAge(kittens));
            Console.WriteLine("Average age of the tomcats: {0}", Animal.AverageAge(tomcats));
            Console.WriteLine("Average age of the frogs: {0}", Animal.AverageAge(frogs));

            Dog myDog = new Dog("Mecho", 4, "male", "Pug");
            myDog.MakeSound();
            Kitten myKitten = new Kitten("Moli", 1, "female", "Nebelung");
            myKitten.MakeSound();
            myKitten.Purr();
            Tomcat myTomcat = new Tomcat("Tobi", 1, "male", "Ragamuffin");
            myTomcat.MakeSound();
            myTomcat.Sleep();
            Frog myFrog = new Frog("Kvakcho", 1, "male", 3);
            myFrog.MakeSound();
            myFrog.Jump();
        }

        
    }
}
