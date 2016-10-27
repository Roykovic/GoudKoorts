using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GoudKoorts.Domain
{
    public abstract class Visitor
    {
        public abstract void Visit(EmptyTrack visitee);
        public abstract void Visit(Track visitee);
        public abstract void Visit(MovableTrack visitee);
        public abstract void Visit(ArrangeTrack visitee);
        public abstract void Visit(Pier visitee);
        public abstract void Visit(Cart visitee);
        public abstract void Visit(Boat visitee);
    }
}
