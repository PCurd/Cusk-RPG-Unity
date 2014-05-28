using Cusk_Library.Entities;
using System;
namespace Cusk_Library.Engine
{
    public interface ICuskEngine
    {
        int TickMSLength { get; }
        bool CanMoveTo(int NewX, int NewY, ICuskEntity CuskEntity);

        void RunTick();
    }
}
