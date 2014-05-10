using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cusk_Library 
{
    public class GameState : Cusk_Library.IGameState
    {
        private bool InGoodForm;
        private IGameStateChecker gameStateChecker;

        public GameState(IGameStateChecker gameStateChecker)
        {
            this.gameStateChecker = gameStateChecker;
            InGoodForm = false;
        }

        public string Serialize()
        {
            if (gameStateChecker.Check(this))
                return this.ToString();
            else throw new ArgumentException("Object GameState not in good form");
        }

        private bool CheckForm()
        {
            return InGoodForm;
        }
    }
}
