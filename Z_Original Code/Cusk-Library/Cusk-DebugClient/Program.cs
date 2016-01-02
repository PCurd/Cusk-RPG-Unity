using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cusk_Library;
using Cusk_Library.Engine;
using Cusk_Library.Entities;

namespace Cusk_DebugClient
{
    class Program
    {
        static void Main(string[] args)
        {

            var cuskEngine = new Cusk_Library.Engine.CuskEngine(new Cusk_Library.Engine.CuskEntityDatabase(),new TimeSpan(500000));

            cuskEngine.AddCuskEntity(new Player(1,1,1,1,1,1,1,cuskEngine));

            cuskEngine.RunTick();
            cuskEngine.RunTick();

            cuskEngine.RunTick();
            cuskEngine.RunTick();

            cuskEngine.cuskObjectDatabase.ForEachEntity(x=>Console.WriteLine("{0} {1} {2}",x.CurrentX, x.CurrentY, x.ToString()));

            Console.WriteLine("Goodbye"); Console.ReadKey();
        }
    }
}
