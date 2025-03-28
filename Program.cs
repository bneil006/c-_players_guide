using PlayerHelpers;

ColoredWeapon<Axe> newAxe = new ColoredWeapon<Axe>(WeaponColors.Red);
ColoredWeapon<Bow> newBow = new ColoredWeapon<Bow>(WeaponColors.Green);
ColoredWeapon<Dagger> newDagger = new ColoredWeapon<Dagger>(WeaponColors.Blue);

newAxe.DisplayWeapon();
newBow.DisplayWeapon();
newDagger.DisplayWeapon();

Console.ReadLine();