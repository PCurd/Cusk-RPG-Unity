using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cusk_Library
{
    public interface ICuskObject
    {

        //TODO: In future actually return XML or whatever for saving
        string Serialize();
    }
}
