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

public class Track
{
	public virtual object Track nextTrack
	{
		get;
		set;
	}

	public virtual Cart Cart
	{
		get;
		set;
	}

	public virtual void visit(object this)
	{
		throw new System.NotImplementedException();
	}

        public virtual void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
}

