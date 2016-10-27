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
    public class MovableTrack : Track
    {
        public MovableTrack()
        {
            corner = 0;
        }
        public override PlacableObject content
        {
            get;
            set;
        }
        public void move(int direction) 
        {
            this.corner = direction;
        }
        override public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
        public override bool Place(PlacableObject content)
        {
            if (this.content == null)
            {
                if (this.previousTrack == null || this.previousTrack.content != content) {return false; }
                if (this.nextTrack == null||this.nextTrack.corner == -1) { return false; }
                this.previousTrack.content = null;
                this.content = content;
                this.content.Track = this;
                return true;
            }
            return false;
        }
    }
}

