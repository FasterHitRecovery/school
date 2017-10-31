using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Test.Model.Entity;

namespace Test.Run
{
    class Program
    {
        static void Main(string[] args)
        {
            Card card = new Card();
            Trait lord = new Trait();
            lord.Name = "Lord";
            card.Trait.Add(lord);

            Console.WriteLine(card.Trait);
        }
    }
}
