﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoudKoorts.Domain
{
    public class Pier : Track
    {
        public Boat _boat;
        public virtual Boat Boat
        {
            get{return _boat;}
            set{_boat = value;}
        }
        override public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
        public override bool Place(PlacableObject content)
        {
            if (this.content == null)
            {
                
                if (this.previousTrack != null) { this.previousTrack.content = null; }
                this.content = content;
                this.content.Track = this;
                if (this.Up.content != null) { 
                    this.Boat = (Boat)this.Up.content; 
                }
                fillShip();
                return true;
            }
            return false;
        }
        public void fillShip() 
        {
            if (this.Boat != null && !Boat.moving) 
            {
                Boat.ChangeFilling();
                content.ChangeFilling();
                
            }
        }
    }
}

