using Cusk_Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cusk_Library.Engine
{
    public class CuskEngine : ICuskEngine
    {
        public CuskEntityDatabase cuskObjectDatabase;
        public CuskEngine(CuskEntityDatabase cuskObjectDatabase)
        {
            this.cuskObjectDatabase = cuskObjectDatabase;

        }
        public bool CanMoveTo(int NewX, int NewY, ICuskEntity CuskEntity)
        {
            //Source and destination are the same
            if (NewX == CuskEntity.CurrentX && NewY == CuskEntity.CurrentY) return false;
            //Another entity is on this space
            if (cuskObjectDatabase.IsEntityAtLoc(NewX, NewY)) return false;

            return true;
        }
    }
}
