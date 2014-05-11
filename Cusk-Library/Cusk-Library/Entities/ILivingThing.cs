using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cusk_Library.Entities
{
    interface ILivingThing
    {
        int HP { get; }
        int MaxHP { get; }
        int MP { get; }
        int MaxMP { get; }
        int OriginalX { get; }
        int OriginalY { get; }
        int Strength { get; }
        int Intelligence { get; }
        int Dexterity { get; }
        int Constitution { get; }
        int Wisdom { get; }
        int Experience { get; }
        Guid ID { get; }

        bool MoveTo(int NewX, int NewY);
    }
}
