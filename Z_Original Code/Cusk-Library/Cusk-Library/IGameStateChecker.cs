using System;
namespace Cusk_Library
{
    public interface IGameStateChecker
    {
        bool Check(IGameState gameState);
    }
}
