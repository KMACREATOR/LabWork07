using System;

namespace ReflectionLibrary
{
    public enum eClassificationAnimal
    {
        Herbivores,
        Carnivores,
        Omnivores
    }

    public enum eFavoriteFood
    {
        Meat,
        Plants,
        Everything
    }

    // Custom attribute
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class CommentAttribute : Attribute
    {
        public string Comment { get; }

        public CommentAttribute(string comment)
        {
            Comment = comment;
        }
    }

    [Comment("Abstract class representing an animal")]
    public abstract class Animal
    {
        public string Country { get; set; }
        public bool HideFromOtherAnimals { get; set; }
        public string Name { get; set; }
        public eClassificationAnimal WhatAnimal { get; set; }

        public abstract eFavoriteFood GetFavouriteFood();

        public abstract void SayHello();
    }

    [Comment("Class representing a cow")]
    public class Cow : Animal
    {
        public Cow()
        {
            WhatAnimal = eClassificationAnimal.Herbivores;
        }

        public override eFavoriteFood GetFavouriteFood()
        {
            return eFavoriteFood.Plants;
        }

        public override void SayHello()
        {
            Console.WriteLine("Moo!");
        }
    }

    [Comment("Class representing a lion")]
    public class Lion : Animal
    {
        public Lion()
        {
            WhatAnimal = eClassificationAnimal.Carnivores;
        }

        public override eFavoriteFood GetFavouriteFood()
        {
            return eFavoriteFood.Meat;
        }

        public override void SayHello()
        {
            Console.WriteLine("Roar!");
        }
    }

    [Comment("Class representing a pig")]
    public class Pig : Animal
    {
        public Pig()
        {
            WhatAnimal = eClassificationAnimal.Omnivores;
        }

        public override eFavoriteFood GetFavouriteFood()
        {
            return eFavoriteFood.Everything;
        }

        public override void SayHello()
        {
            Console.WriteLine("Oink!");
        }
    }
}
