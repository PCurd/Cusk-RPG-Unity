using Cusk_Library.Entities;
using System;
using System.Collections.Generic;
namespace Cusk_Library.Engine
{
    public interface ICuskEntityDatabase
    {
        List<ICuskEntity> CuskEntities { get; }
        ICuskEntity GetEntityAtLoc(int LocX, int LocY);
        bool IsEntityAtLoc(int LocX, int LocY);
        bool AddToDatabase(ICuskEntity cuskEntity);
    }
}
