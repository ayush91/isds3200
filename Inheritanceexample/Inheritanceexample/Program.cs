using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritanceexample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person regularPerson = new Person();
            //regularPerson.name = "Mike the Tiger";

            Person regularPerson = new Person("Mike the Tiger");
            
            //Hero superMan = new Hero();
            //superMan.name = "Superman";

            Hero superMan = new Hero("Superman", "Invincible");
            superMan.ability = "Fly";
            superMan.ability = "Invinsible unless green rocks";
            Villan evilWitch = new Villan("Evil Witch");
            evilWitch.badDeeds.Add("Casts Spells");
            evilWitch.badDeeds.Add("Cooks Kids");

        }
        class Person
        {
            public string name;
            public Person(string Pname)
            {
                this.name = Pname;
            }
            public override string ToString()
            {
                return this.name;
            }
        }
        class Hero : Person
        {
            public string ability;
            public Hero (string pName, string pAbility): base(pName)
            {

            }
        }
        class Villan : Person
        {

        }
    }
}
