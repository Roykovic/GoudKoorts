﻿using GoudKoorts.Domain;
//------------------------------------------------------------------------------
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
    public class Boat : PlacableObject
    {
        public Boat(Track track) 
        {
            if (Track == null) { Track = track; }
            
        }
        public bool onPier;
        public bool moving = false;
        public virtual int Cargo
        {
            get;
           
            set ;
            
            
        }

        public override bool Move()
        {
            if (Track == null) 
            { 
            
            }
            if (Track.Right == null||!onPier) 
            {
                return Track.Left.Place(this);
            }
             if (Cargo < 8) { return false ; }
             moving = true;
             if (Track != null)
             {

                 if (Track.Left != null)
                 {
                     return Track.Left.Place(this);
                 }

                 this.Track.content = null;
                 this.Track = null;
                 return true;
             }
            return false;
        }

        override public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public override void ChangeFilling()
        {
            this.Cargo++;
        }
    }
}

