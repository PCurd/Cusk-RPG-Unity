using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cusk_Library.Entities
{
    public interface ICuskEntity
    {
        int CurrentX { get; }
        int CurrentY { get; }

        void DoMoves();
    }
}
