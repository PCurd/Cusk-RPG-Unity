using Cusk_Library.Entities;
using System;
namespace Cusk_Library.Engine
{
    public interface ICuskEngine
    {
        int TickMSLength { get; }
     
        bool EntityCanMoveTo(int NewX, int NewY, ICuskEntity CuskEntity);

        void RunTick();

        void AddCuskEntity(ICuskEntity cuskEntity);
    }
}
