using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cusk_Library
{
    public class Save : Cusk_Library.ISave
    {
        public Save()
        {

        }


        //In future needs to store serialized output
        public bool Serialize(ICuskObject cuskObject)
        {
            try
            {

                var serialized = cuskObject.Serialize();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
