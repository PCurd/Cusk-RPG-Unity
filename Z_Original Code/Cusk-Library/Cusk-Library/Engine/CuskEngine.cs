using Cusk_Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cusk_Library.Engine
{


    class StateObjClass
    {
        // Used to hold parameters for calls to TimerTask. 
        public int SomeValue;
        public System.Threading.Timer TimerReference;
        public bool TimerCanceled;
    }


    public class CuskEngine : ICuskEngine
    {
        public ICuskEntityDatabase cuskObjectDatabase;
        private DateTime Started;
        private DateTime EndOfTick;
        private TimeSpan TickLength;
        public int TickMSLength { get; private set; }
        public CuskEngine(CuskEntityDatabase cuskObjectDatabase, TimeSpan TickLength)
        {
            Started = DateTime.UtcNow;
            this.cuskObjectDatabase = cuskObjectDatabase;
            this.TickLength = TickLength;
            this.EndOfTick = DateTime.MinValue;

        }
        public bool EntityCanMoveTo(int NewX, int NewY, ICuskEntity CuskEntity)
        {
            //Source and destination are the same
            if (NewX == CuskEntity.CurrentX && NewY == CuskEntity.CurrentY) return false;
            //Another entity is on this space
            if (cuskObjectDatabase.IsEntityAtLoc(NewX, NewY)) return false;

            return true;
        }

        public void RunTick()
        {
            DateTime StartOfTick = DateTime.UtcNow;


            StateObjClass StateObj = new StateObjClass();
            StateObj.TimerCanceled = false;
            StateObj.SomeValue = 1;
            //System.Threading.TimerCallback TimerDelegate =
            //    new System.Threading.TimerCallback(TimerTask);


            //// Create a timer that calls a procedure every 2 seconds. 
            //// Note: There is no Start method; the timer starts running as soon as  
            //// the instance is created.
            //System.Threading.Timer TimerItem =
            //    new System.Threading.Timer(TimerDelegate, StateObj, 2000, 2000);

            //// Save a reference for Dispose.
            //StateObj.TimerReference = TimerItem;

            //// Run for ten loops. 
            //while (StateObj.SomeValue < 10)
            //{
            //    // Wait one second.
            //    System.Threading.Thread.Sleep(1000);
            //}

            //// Request Dispose of the timer object.
            //StateObj.TimerCanceled = true;  

            TimerTask(StateObj);

            EndOfTick = DateTime.UtcNow;
            TimeSpan ActualTickLength;
            ActualTickLength =  EndOfTick - StartOfTick;
            TickMSLength = (int)ActualTickLength.TotalMilliseconds;



        }

        public void AddCuskEntity(ICuskEntity cuskEntity)
        {
            try
            {
                var result = cuskObjectDatabase.AddToDatabase(cuskEntity);
            }
            catch (Exception ex)
            {
                //Do something
            }
        }

        //private void DoTick()
        //{
        //    Thread.Sleep(TickLength); //Five seconds

        //    //At the end of the tick... 
        //    LastTick = DateTime.UtcNow;
        //}

        private void TimerTask(object StateObj)
        {
            StateObjClass State = (StateObjClass)StateObj;
            // Use the interlocked class to increment the counter variable.
            System.Threading.Interlocked.Increment(ref State.SomeValue);
            if (State.TimerCanceled)
            // Dispose Requested.
            {
                State.TimerReference.Dispose();
            }
            
            // Do Stuff

            cuskObjectDatabase.ForEachEntity(e => e.DoMoves());

            Thread.Sleep(TickLength);

            
        }
    }
}
