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
        public virtual int Cargo
        {
            get;
            set;
        }

        public override void Move()
        {
            throw new System.NotImplementedException();
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

