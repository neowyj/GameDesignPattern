using System;

namespace DecoratorPattern
{
    public interface Weapon
    {
        void Fire();
    }

    public class Gun: Weapon
    {
        public void Fire()
        {
            Console.WriteLine("Shooting");
        }
    }

    public class Decorator: Weapon
    {
        private Weapon Weapon;

        public Decorator(Weapon Weapon)
        {
            this.Weapon = Weapon;
        }

        public virtual void Fire()
        {
            Weapon.Fire();
        }
    }

    public class AK47Decorator: Decorator
    {
        public AK47Decorator(Weapon Weapon): base(Weapon)
        {

        }

        public override void Fire()
        {
            base.Fire();
            AK47Func();
        }

        public void AK47Func()
        {
            Console.WriteLine("AK47 Shooting");
        }

    }

    public class M4A1Decorator: Decorator
    {
        public M4A1Decorator(Weapon Weapon) : base(Weapon)
        {

        }

        public override void Fire()
        {
            base.Fire();
            M4A1Func();
        }

        public void M4A1Func()
        {
            Console.WriteLine("M4A1 Shooting");
        }
    }

    public class client
    {
        public static void Main1(string[] args)
        {
            Weapon gun = new Gun();
            Weapon ak47 = new AK47Decorator(gun);
            Weapon m4a1 = new M4A1Decorator(gun);
            ak47.Fire();
            m4a1.Fire();
        }
    }
}


