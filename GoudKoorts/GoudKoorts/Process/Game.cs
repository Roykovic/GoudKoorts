﻿using Goudkoorts.Process;
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
namespace Goudkoorts.process
{
    public class Game
    {
        Controller c;

        public Game()
        {
            c = new Controller();
            this.Start();
        }
        public virtual Controller Controller
        {
            get;
            set;
        }

        public virtual void Start()
        {
            c.go();
        }

    }
}

