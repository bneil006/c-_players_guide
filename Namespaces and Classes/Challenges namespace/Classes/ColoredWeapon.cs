using System;
using System.Collections.Generic;

namespace Challenges
{
    public class Bow { }

    public class Axe { }

    public class Dagger { }

    public class ColoredWeapon<T>where T : class
    {
        public WeaponColors Color { get; set; }
        public string Name
        {
            get
            {
                Type baseClass = typeof(T);
                return baseClass.Name;
            }
        }
        public ColoredWeapon(WeaponColors color)
        {
            Color = color;
        }

        public void DisplayWeapon()
        {
            Console.WriteLine($"{Color} {Name}");
        }
    }

    public enum WeaponColors
    {
        Blue,
        Green,
        Red
    }
}