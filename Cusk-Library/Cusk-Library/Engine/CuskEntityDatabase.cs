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

        public string Serialize()
        {
            return this.ToString();
        }
    }
}
