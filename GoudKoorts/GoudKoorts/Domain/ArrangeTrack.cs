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
    public class ArrangeTrack : Track
    {
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
                return true;
            }
            return true;
        }
    }
    
}

