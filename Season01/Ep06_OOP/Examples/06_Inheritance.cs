namespace Ep06.Examples;

public static class Ex06_Inheritance
{
    // abstract class: cannot be instantiated, may have abstract members (no body)
    abstract class Animal
    {
        public string Name { get; }
        protected Animal(string name) => Name = name;

        public abstract string Sound();                        // must be overridden

        // virtual: CAN be overridden. Methods are NOT virtual by default (unlike JS/Java)
        public virtual string Describe() => $"{Name} says {Sound()}";
    }

    class Dog : Animal                                         // JS: class Dog extends Animal
    {
        public Dog(string name) : base(name) { }               // JS: super(name)
        public override string Sound() => "Woof";
    }

    class Puppy : Dog
    {
        public Puppy(string name) : base(name) { }
        public override string Describe() => base.Describe() + " (tiny)";   // JS: super.describe()
    }

    // sealed: no one can inherit from this class
    sealed class Cat : Animal
    {
        public Cat(string name) : base(name) { }
        public override string Sound() => "Meow";
    }

    // class Lion : Cat { }    // compile error: cannot derive from sealed type

    public static void Run()
    {
        // var a = new Animal("x");   // compile error: abstract
        List<Animal> zoo = [new Dog("Rex"), new Puppy("Bit"), new Cat("Tom")];
        foreach (var animal in zoo)
            Console.WriteLine(animal.Describe());   // runtime picks the override (polymorphism)

        // Type checks and casts
        Animal some = zoo[1];
        if (some is Dog d) Console.WriteLine($"{d.Name} is a Dog (or subclass)");
        Console.WriteLine(some.GetType().Name);     // Puppy

        // Every class ultimately derives from `object`, which has ToString, Equals, GetHashCode.
    }
}
