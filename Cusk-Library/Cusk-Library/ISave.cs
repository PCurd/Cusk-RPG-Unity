using System;
namespace Cusk_Library
{
    public interface ISave
    {
        bool Serialize(ICuskObject cuskObject);
    }
}
