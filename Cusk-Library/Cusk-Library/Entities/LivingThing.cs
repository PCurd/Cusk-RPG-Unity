using Cusk_Library.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cusk_Library.Entities
{
    public class LivingThing : ICuskObject, ICuskEntity, ILivingThing
    {
        private ICuskEngine cuskEngine;

        public int HP {get;private set;}
        public int MaxHP { get; private set; }
        public int MP { get; private set; }
        public int MaxMP { get; private set; }
        public int OriginalX { get; private set; }
        public int OriginalY { get; private set; }
        public int Strength { get; private set; }
        public int Intelligence { get; private set; }
        public int Dexterity { get; private set; }
        public int Constitution { get; private set; }
        public int Wisdom { get; private set; }
        public int Experience { get; private set; }

        private readonly Guid _ID;
        public Guid ID { get { return _ID; } }

        //From ICuskObject
        public int CurrentX { get; private set; }
        public int CurrentY { get; private set; }

        public LivingThing(int MaxHP, int MaxMP, int Strength, int Intelligence, int Dexterity, int Constitution, int Wisdom, ICuskEngine cuskEngine)
        {
            this.cuskEngine = cuskEngine; 
            this.MaxHP = MaxHP;
            this.MaxMP = MaxMP;
            this.Strength = Strength;
            this.Intelligence = Intelligence;
            this.Dexterity = Dexterity;
            this.Constitution = Constitution;
            this.Wisdom = Wisdom;

            this.HP = this.MaxHP;
            this.MP = this.MaxMP;
            this.Experience = 0;
            this.OriginalX = 0;
            this.OriginalY = 0;
            this._ID = new Guid();
            
        }

        public string Serialize()
        {
            return this.ToString();
        }

        public bool MoveTo(int NewX, int NewY)
        {
            if (cuskEngine.CanMoveTo(NewX, NewY, this))
            {
                CurrentX = NewX;
                CurrentY = NewY;
                return true;
            }
            else return false;
        }

        public void DoMoves()
        {
            MoveTo(CurrentX + 1, CurrentY);
        }


    }
}
