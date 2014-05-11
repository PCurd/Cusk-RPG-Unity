using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cusk_Library.Entities
{
    public class Player : LivingThing
    {
        public Player(int MaxHP, int MaxMP, int Strength, int Intelligence, int Dexterity, int Consitution, int Wisdom)
            : base(MaxHP, MaxMP, Strength, Intelligence, Dexterity, Consitution, Wisdom)
	{
         
	}
    }
}
