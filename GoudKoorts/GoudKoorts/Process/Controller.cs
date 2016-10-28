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
using Goudkoorts.presentation;
using System.Threading;
namespace Goudkoorts.Process
{
    public class Controller
    {
        public Random rnd;
        public Thread show;
        public bool newStep;
        public bool gameOver;
        public int timerInt = 20;
        public Controller()
        {
            this.model = new Board(11, 9);
            this.view = new BoardView();
        }
        public virtual BoardView view
        {
            get;
            set;
        }

        public virtual Board model
        {
            get;
            set;
        }

        public void go()
        {
            InitBoard();
            rnd = new Random();
            int randInt = rnd.Next(3);
            if (model.Routes.Length > randInt)
            {
                var field = model.Routes[randInt].OriginField;
                field.Place(new Cart(field));
            }
            timer();
        }
        public void askInput()
        {

            var input = view.askInput();
            var keyInt = input.KeyChar - '0';
            if (keyInt > 5 || keyInt < 1)
            {
                view.ShowError("Er bestaat geen draaibare rails met nummer " + keyInt);
                askInput();
            }
            try { model.MovableTracks[keyInt - 1].move(); }
            catch (Exception e) { view.ShowError(e.ToString()); askInput(); }
            

        }
        public virtual void InitBoard()
        {
            Track[,] boardArray = new Track[9, 11];
            int totalX = 0;
            for (int x = 0; x < model.height; x++)
            {
                for (int y = 0; y < model.width; y++)
                {
                    totalX++;
                    var c = model.boardString[totalX];
                    switch (c)
                    {
                        case 'B':
                            boardArray[x, y] = new EmptyTrack();
                            boardArray[x, y].content = new Boat(boardArray[x, y]);
                            model.boat = (Boat) boardArray[x, y].content;
                            break;
                        case '-':
                            boardArray[x, y] = new Track();
                            boardArray[x, y].corner = 0;
                            break;
                        case 'K':
                            boardArray[x, y] = new Pier();
                            break;
                        case 'a':
                            boardArray[x, y] = new ArrangeTrack();
                            break;
                        case '1':
                        case '2':
                        case '3':
                            boardArray[x, y] = new Track();
                            model.Routes[c - '1'] = new Route();
                            model.Routes[c - '1'].OriginField = boardArray[x, y];
                            break;
                        case '@':
                            boardArray[x, y] = new MovableTrack();
                            model.MovableTracks.Add((MovableTrack)boardArray[x, y]);
                            break;
                        case ' ':
                            boardArray[x, y] = new EmptyTrack();
                            break;
                        case '┐':
                            boardArray[x, y] = new Track();
                            boardArray[x, y].corner = 1;
                            break;
                        case '┌':
                            boardArray[x, y] = new Track();
                            boardArray[x, y].corner = 2;
                            break;
                        case '┘':
                            boardArray[x, y] = new Track();
                            boardArray[x, y].corner = 3;
                            break;
                        case '└':
                            boardArray[x, y] = new Track();
                            boardArray[x, y].corner = 4;
                            break;
                        case '|':
                            boardArray[x, y] = new Track();
                            boardArray[x, y].corner = 5;
                            break;
                        default:
                            break;
                    }

                    boardArray[x, y].x = x;
                    boardArray[x, y].y = y;
                }
            }
            model.boardArray = boardArray;
            model.MovableTracks[0].corner = 2;
            model.MovableTracks[1].corner = 1;
            model.MovableTracks[2].corner = 2;
            model.MovableTracks[3].corner = 2;
            model.MovableTracks[4].corner = 1;
            InitNeighbours();
        }

        public void InitNeighbours()
        {
            foreach (Track t in model.boardArray)
            {
                var arr = model.boardArray;
                var coords = CoordinatesOf<Track>(arr, t);
                var y = coords.Item1;
                var x = coords.Item2;
                if (t.corner >= 0)
                {
                    
                    if (y < model.height - 1) { t.Down = arr[y + 1, x]; }
                    if (y > 0) { t.Up = arr[y - 1, x]; }
                    if (x > 0) { t.Left = arr[y, x - 1]; }
                    if (x < model.width - 1) { t.Right = arr[y, x + 1]; }
                }
                else 
                {
                    if (x > 0) { t.Left = arr[y, x - 1]; }
                    if (x < model.width - 1) { t.Right = arr[y, x + 1]; }
                }
            }

            InitRoutes();
        }

        public void InitRoutes()
        {

            foreach (Route r in model.Routes)
            {
                r.FinalField = null;

                var current = r.OriginField;
                Track oldCurrent = current;
                var next = current.Right;
                current.nextTrack = next;
                while (next != null && r.FinalField == null)
                {
                    int caseSwitch = next.corner;
                    switch (caseSwitch)
                    {
                        case 0:
                            if (next.Left == current) { next.previousTrack = next.Left; next.nextTrack = next.Right; break; }
                            if (next.Right == current) { next.nextTrack = next.Left; next.previousTrack = next.Right; break; }
                            r.FinalField = current;
                            break;
                        case 1:
                            if (next.Left == current) { next.previousTrack = next.Left; next.nextTrack = next.Down; break; }
                            if (next.Down == current) { next.nextTrack = next.Left; next.previousTrack = next.Down; break; }
                            r.FinalField = current;
                            break;
                        case 2:
                            if (next.Right == current) { next.previousTrack = next.Right; next.nextTrack = next.Down; break; }
                            if (next.Down == current) { next.nextTrack = next.Right; next.previousTrack = next.Down; break; }
                            r.FinalField = current;
                            break;
                        case 3:
                            if (next.Left == current) { next.previousTrack = next.Left; next.nextTrack = next.Up; break; }
                            if (next.Up == current) { next.nextTrack = next.Left; next.previousTrack = next.Up; break; }
                            r.FinalField = current;
                            break;
                        case 4:
                            if (next.Right == current) { next.previousTrack = next.Right; next.nextTrack = next.Up; break; }
                            if (next.Up == current) { next.nextTrack = next.Right; next.previousTrack = next.Up; break; }
                            r.FinalField = current;
                            break;
                        case 5:
                            if (next.Up == current) { next.previousTrack = next.Up; next.nextTrack = next.Down; break; }
                            if (next.Down == current) { next.nextTrack = next.Up; next.previousTrack = next.Down; break; }
                            r.FinalField = current;
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;

                    }
                    oldCurrent = current;
                    current = current.nextTrack;
                    next = current.nextTrack;
                }
                if (r.FinalField == null)
                {
                    r.FinalField = oldCurrent;
                }
            }
        }
        public void moveCarts()
        {


            foreach (Route r in model.Routes)
            {
                var current = r.FinalField;
                while (current != null)
                {
                    var previous = current.previousTrack;
                    if (current.content != null)
                    {
                       current.content.Move();
                    }
                    
                    current = previous;
                }
                if (model.boardArray[1, 0].content != null) 
                { 
                    model.boardArray[1, 0].content = null; 
                }
                model.boat.Move();
            }

            rnd = new Random();
            int randInt = rnd.Next(6);
            if (model.Routes.Length > randInt)
            {
                var field = model.Routes[randInt].OriginField;
                field.Place(new Cart(field));
            }

        }
        public void timer()
        {
            newStep = false;
            int counter = timerInt;
            show = new Thread(() =>
            {
                while (!newStep)
                {
                    if (counter < 0) { Step(); }
                    

                    InitRoutes();
                    view.Show(model, counter);
                    Thread.Sleep(1000);
                    counter--;
                };
            });
            show.Start();
            do
            {
                askInput();
            } while (true);
        }

        public virtual void Step()
        {
            if (timerInt > 5) { timerInt--; }
            newStep = true;
            moveCarts();
            if (!gameOver) { timer(); }
            else { view.gameOver(); }
        }

        public Tuple<int, int> CoordinatesOf<T>(T[,] matrix, T value)
        {
            int w = matrix.GetLength(0); // width
            int h = matrix.GetLength(1); // height

            for (int x = 0; x < w; ++x)
            {
                for (int y = 0; y < h; ++y)
                {
                    if (matrix[x, y].Equals(value))
                        return Tuple.Create(x, y);
                }
            }

            return Tuple.Create(-1, -1);
        }
    }
}

