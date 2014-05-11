using Cusk_Library.Entities;
using System;
namespace Cusk_Library.Engine
{
    public interface ICuskEngine
    {
        bool CanMoveTo(int NewX, int NewY, ICuskEntity CuskEntity);
    }
}
