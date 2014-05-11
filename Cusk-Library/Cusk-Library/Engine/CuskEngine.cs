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
        private CuskEntityDatabase cuskObjectDatabase;
        public CuskEngine(CuskEntityDatabase cuskObjectDatabase)
        {
            this.cuskObjectDatabase = cuskObjectDatabase;

        }
        public bool CanMoveTo(int NewX, int NewY, ICuskEntity CuskEntity)
        {
            if (NewX == CuskEntity.CurrentX && NewY == CuskEntity.CurrentY) return false;
            //TODO: Check if another entity is blocking the way

            return false;
        }
    }
}
