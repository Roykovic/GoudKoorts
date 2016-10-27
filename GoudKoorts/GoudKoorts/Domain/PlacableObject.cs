using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Domain
{
    abstract public class PlacableObject
    {
       public abstract void Accept(Visitor visitor);
       public abstract bool Move();
       public abstract void ChangeFilling();
       public Track Track;
    }


}
