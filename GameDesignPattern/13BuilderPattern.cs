using System;

namespace BuilderPattern
{
    public class SetMeal
    {
        private string hamburger;
        private string chickenWing;
        private string drink;

        public void SetHamburger(string hamburger)
        {
            this.hamburger = hamburger;
        }

        public void SetChickenWing(string chickenWing)
        {
            this.chickenWing = chickenWing;
        }

        public void SetDrink(string drink)
        {
            this.drink = drink;
        }

        public void Show()
        {
            Console.WriteLine(hamburger + "," + chickenWing + "," + drink);
        }
    }

    public abstract class Cook
    {
        public SetMeal setMeal = new SetMeal();

        public abstract void BuildHamburger();
        public abstract void BuildChickenWing();
        public abstract void BuildDrink();

        public SetMeal GetSetMeal()
        {
            return setMeal;
        }
    }

    public class CookA : Cook
    {
        public override void BuildHamburger()
        {
            setMeal.SetHamburger("鸡肉汉堡");
        }

        public override void BuildChickenWing()
        {
            setMeal.SetChickenWing("香辣鸡翅");
        }

        public override void BuildDrink()
        {
            setMeal.SetDrink("可乐");
        }
    }

    public class CookB : Cook
    {
        public override void BuildHamburger()
        {
            setMeal.SetHamburger("牛肉汉堡");
        }

        public override void BuildChickenWing()
        {
            setMeal.SetChickenWing("甜辣鸡翅");
        }

        public override void BuildDrink()
        {
            setMeal.SetDrink("雪碧");
        }
    }

    public class Waiter
    {
        private Cook cook;

        public Waiter(Cook cook)
        {
            this.cook = cook;
        }

        public SetMeal Construct()
        {
            cook.BuildHamburger();
            cook.BuildChickenWing();
            cook.BuildDrink();
            return cook.GetSetMeal();
        }
    }

    public class BuilderPatternDemo
    {
        public static void Main1(string[] args)
        {
            Cook cookA = new CookA();
            Waiter waiterA = new Waiter(cookA);
            SetMeal setMealA = waiterA.Construct();
            setMealA.Show();

            Cook cookB = new CookB();
            Waiter waiterB = new Waiter(cookB);
            SetMeal setMealB = waiterB.Construct();
            setMealB.Show();
        }
    }
}
