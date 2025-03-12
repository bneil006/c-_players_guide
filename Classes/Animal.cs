using System;

namespace Classes
{
    class Animal
    {
        public virtual bool wings {  get; set; } = false;
        public void Flee()
        {
            if (wings)
            {
                Console.WriteLine("The animal Flees on Wings");
            }
            else
            {
                Console.WriteLine("The animal Flees on Foot");
            }
        }
    }

    class Dog : Animal
    {

    }

    class Bird : Animal
    {
        public override bool wings { get; set; } = true;
    }

    class Cat : Animal
    {
        
    }
}
