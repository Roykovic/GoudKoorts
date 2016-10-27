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
using GoudKoorts.Domain;
namespace Goudkoorts.presentation
{
    public class BoardView : Visitor
    {

        private char _fieldRepresentation;
        public virtual void Show(Board board, int timer)
        {
            Console.Clear();
            _fieldRepresentation = '?';
            int rowLength = board.height;
            int colLength = board.width;
            var boardArray = board.boardArray;
            Console.WriteLine("Volgende stap in: " + timer);
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    boardArray[i, j].Accept(this);
                    Console.Write(_fieldRepresentation);
                    Console.ResetColor();
                }
                Console.Write("\n");
            }
            Console.WriteLine("\nTyp het nummer van de draaibare rails  ");
            Console.WriteLine("Met direct daarna de gewenste hoek: 0 = -, 1 = ┐. 2 = ┌, 3 = ┘, 4 = └");
        }
        public String askInput() 
        {
            return Console.ReadLine();
        }
        public void ShowError(String error) 
        {
            Console.WriteLine(error);
        }
        override public void Visit(EmptyTrack visitee) 
        {
            _fieldRepresentation = ' ';
            if (visitee.content != null) { visitee.content.Accept(this); }
        }

        public void gameOver() 
        {
            Console.Clear();
            Console.WriteLine("Game Over");
            Console.ReadLine();
        }
        override public void Visit(Track visitee)
        {
            int caseSwitch = visitee.corner;
            switch (caseSwitch)
            {
                case 0:
                    _fieldRepresentation = '-';
                    break;
                case 1:
                    _fieldRepresentation = '┐';
                    break;
                case 2:
                    _fieldRepresentation = '┌';
                    break;
                case 3:
                    _fieldRepresentation = '┘';
                    break;
                case 4:
                    _fieldRepresentation = '└';
                    break;
                case 5:
                    _fieldRepresentation = '|';
                    break;
            }
            if (visitee.content != null) { visitee.content.Accept(this); }
        }
        override public void Visit(MovableTrack visitee)
        {
            int caseSwitch = visitee.corner;
            switch (caseSwitch)
            {
                case 0:
                    _fieldRepresentation = '-';
                    break;
                case 1:
                    _fieldRepresentation = '┐';
                    break;
                case 2:
                    _fieldRepresentation = '┌';
                    break;
                case 3:
                    _fieldRepresentation = '┘';
                    break;
                case 4:
                    _fieldRepresentation = '└';
                    break;
                case 5:
                    _fieldRepresentation = '|';
                    break;
            }
            if (visitee.content != null) { visitee.content.Accept(this); }
            Console.BackgroundColor = ConsoleColor.Red;
        }
        override public void Visit(ArrangeTrack visitee)
        {

            _fieldRepresentation = 'a';
            if (visitee.content != null) { visitee.content.Accept(this); }
        }
        override public void Visit(Pier visitee)
        {
            _fieldRepresentation = 'K';
            if (visitee.content != null) { visitee.content.Accept(this); }
        }
        override public void Visit(Boat visitee)
        {
            if (visitee.Cargo == 0) { _fieldRepresentation = 'B'; }
            else { _fieldRepresentation = (char)(visitee.Cargo + '0'); }
        }
        override public void Visit(Cart visitee)
        {
            if(visitee.Filled)
            {
           _fieldRepresentation = '█';
            }
            else
            {
            _fieldRepresentation = '▓';
            }
            
        }
    
    
    }
}

