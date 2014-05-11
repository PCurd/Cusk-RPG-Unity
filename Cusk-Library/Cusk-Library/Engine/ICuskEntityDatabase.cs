using Cusk_Library.Entities;
using System;
using System.Collections.Generic;
namespace Cusk_Library.Engine
{
    interface ICuskEntityDatabase
    {
        List<ICuskEntity> CuskEntities { get; }
    }
}
