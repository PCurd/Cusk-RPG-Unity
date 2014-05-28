using Cusk_Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cusk_Library.Engine
{
    public class CuskEntityDatabase : ICuskObject, ICuskEntityDatabase
    {
        public List<ICuskEntity> CuskEntities { get; private set; }

        public CuskEntityDatabase()
        {
            CuskEntities = new List<ICuskEntity>();
        }
        public bool AddToDatabase(ICuskEntity cuskEntity)
        {
            if (CuskEntities.Contains(cuskEntity))
                return false;
            else
            {
                CuskEntities.Add(cuskEntity);
                return true;
            }

        }
        
        public ICuskEntity GetEntityAtLoc(int LocX, int LocY)
        {
            var entity = CuskEntities.First(c => c.CurrentX == LocX && c.CurrentY == LocY);
            return entity;
        }

        public bool IsEntityAtLoc(int LocX, int LocY)
        {
            return CuskEntities.Any(c => c.CurrentX == LocX && c.CurrentY == LocY);
        }

        public string Serialize()
        {
            return this.ToString();
        }

        public void ForEachEntity(Action<ICuskEntity> ActionToPerform)
        {
            CuskEntities.ForEach(x=>ActionToPerform(x));

        }
    }
}
