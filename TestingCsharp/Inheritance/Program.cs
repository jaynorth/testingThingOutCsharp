using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {

        static void Main(string[] args)
        {

            Personne p = new Personne();
            p.Conduire_override();

            Pilote pilote = new Pilote();
            pilote.Conduire_override();
            pilote.Conduire_New();

            Personne personnePilote = new Pilote();
            personnePilote.Conduire_override();
            personnePilote.Conduire_New();

            //transtypage
            Personne George = new Pilote();
            George.Conduire_New();
            Pilote Roger = (Pilote)George;

            Roger.Conduire_New();

            Console.ReadKey();
        }
    }

    public class Personne
    {

        public virtual void Conduire_override()
        {
            Console.WriteLine("personne Conduire override");
        }

        public void Conduire_New()
        {
            Console.WriteLine("personne Conduire new");
        }


    }

    public class Pilote : Personne
    {
        public override void Conduire_override()
        {
            Console.WriteLine("pilote conduire override");
        }

        public new void Conduire_New()
        {
            Console.WriteLine("pilote conduire new");
        }
    }
}
