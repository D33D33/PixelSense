using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Microsoft.Surface.Core;

namespace Enib
{
    namespace SurfaceLib
    {
        public class Behaviour
        {
            int _screenWidth, _screenHeight;
            public Behaviour(int screenWidth, int screenHeigth)
            {
                _screenWidth = screenWidth;
                _screenHeight = screenHeigth;
            }
            public void Update(LinkedList<Sprite> objects, LinkedList<Sprite> selection, LinkedList<MyTouchPoint> touchPoints)
            {
                Sprite bignou = null;
                Sprite batLeft = null;
                Sprite batRight = null;
                foreach (Sprite obj in objects)
                {
                    if (obj.Name == "bignou")
                        bignou = obj;
                    else if (obj.Name == "raquette1")
                        batLeft = obj;
                    else if (obj.Name == "raquette2")
                        batRight = obj;
                }

                // TODO: Add your update logic here
                bignou.Position = bignou.Position + bignou.Speed;
                
                // logique du bignou : collision
                if ((bignou.Speed.X < 0 && bignou.Position.X <= 0) || (bignou.Speed.X > 0 && bignou.Position.X + bignou.Size.Width >= _screenWidth))
                {
                    //bignou.Direction.X = -bignou.Direction.X;
                    Console.WriteLine("GOALLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL!");
                    /*_ballBounceWall.Play();

                    if ((bignou.Speed.X < 0 && bignou.Position.X <= 0))
                    {
                        scoreB++;
                    }
                    else
                    {
                        scoreA++; 
                    }*/

                    bignou.Position = new Vector2((_screenWidth - bignou.Size.Width) / 2, (_screenHeight - bignou.Size.Height) / 2);
                    bignou.Speed *= 0;
                    //bignou.Direction *= 0;
                }
                else if ((bignou.Speed.Y < 0 && bignou.Position.Y <= 0) || (bignou.Speed.Y > 0 && bignou.Position.Y + bignou.Size.Height >= _screenHeight))
                {
                    bignou.Speed = new Vector2(bignou.Speed.X, -bignou.Speed.Y);
                    //_ballBounceWall.Play();
                }


                /************************************************************************************************************************************************
                *                                                       Logic collision raquette Gauche
                ************************************************************************************************************************************************/

                float Y = Math.Min(Math.Min(Math.Max(bignou.Position.Y + bignou.Size.Height - batLeft.Position.Y, 0), Math.Max(batLeft.Position.Y + batLeft.Size.Height - bignou.Position.Y, 0)), bignou.Size.Height);
                float X = Math.Min(Math.Min(Math.Max(bignou.Position.X + bignou.Size.Width - batLeft.Position.X, 0), Math.Max(batLeft.Position.X + batLeft.Size.Width - bignou.Position.X, 0)), bignou.Size.Width);
                
                if (batLeft.BoundingRect.Intersects(new Rectangle((int)bignou.Position.X, (int)bignou.Position.Y, 10, bignou.Size.Height)))
                {
                    float bSpeed = bignou.Speed.X;
                    if (bSpeed < 0)
                        bSpeed = -bSpeed;

                    bignou.Speed = new Vector2(Math.Max(bSpeed, batLeft.Speed.X), batLeft.Speed.Y);
                    bignou.Position = new Vector2(batLeft.Position.X + batLeft.Size.Width, bignou.Position.Y);
                }
                else if (batLeft.BoundingRect.Intersects(new Rectangle((int)bignou.Position.X + bignou.Size.Width -10, (int)bignou.Position.Y, 10, bignou.Size.Height)))
                {
                    float bSpeed = bignou.Speed.X;
                    //if (bSpeed > 0)
                    //    bSpeed = -bSpeed;

                    bignou.Speed = new Vector2(-Math.Max(bSpeed, -batLeft.Speed.X), batLeft.Speed.Y);
                    bignou.Position = new Vector2(batLeft.Position.X - bignou.Size.Width, bignou.Position.Y);
                }

                return;
                if (X < Y)
                {
                    if (batLeft.BoundingRect.Contains((int)bignou.Position.X, (int)bignou.Position.Y) ||
                        batLeft.BoundingRect.Contains((int)bignou.Position.X, (int)bignou.Position.Y + bignou.Size.Height))
                    {
                        if (bignou.Speed.X <= 0)
                        {
                            bignou.Speed = new Vector2(Math.Max(-bignou.Speed.X, batLeft.Speed.X), batLeft.Speed.Y + batLeft.Speed.Y * (float)0.5);
                            //_ballBounceWall.Play();
                        }
                        else if (batLeft.Speed.X > 0)
                        {
                            bignou.Position = new Vector2(bignou.Position.X + batLeft.Speed.X, bignou.Position.Y);
                        }
                    }
                    else if (batLeft.BoundingRect.Contains((int)bignou.Position.X + bignou.Size.Width, (int)bignou.Position.Y) ||
                                batLeft.BoundingRect.Contains((int)bignou.Position.X + bignou.Size.Width, (int)bignou.Position.Y + bignou.Size.Height))
                    {
                        if (bignou.Speed.X >= 0)
                        {
                            bignou.Speed = new Vector2(Math.Min(-bignou.Speed.X, batLeft.Speed.X), bignou.Speed.Y + batLeft.Speed.Y * (float)0.5);
                            //_ballBounceWall.Play();
                        }
                        else if (batLeft.Speed.X < 0)
                        {
                            bignou.Speed = new Vector2( bignou.Speed.X + batLeft.Speed.X,  bignou.Speed.Y);
                        }
                    }
                }

                if (bignou.BoundingRect.Contains((int)batLeft.Position.X, (int)batLeft.Position.Y) ||
                        bignou.BoundingRect.Contains((int)batLeft.Position.X + batLeft.Size.Width, (int)batLeft.Position.Y))
                {
                    if (X > Y)
                    {
                        if (bignou.Speed.Y >= 0)
                        {
                            bignou.Speed = new Vector2( bignou.Speed.X + batLeft.Speed.X * (float)0.5, bignou.Speed.Y + Math.Min(-bignou.Speed.Y, batLeft.Speed.Y));
                            //_ballBounceWall.Play();
                        }
                        else if (batLeft.Speed.Y < 0)
                        {
                            bignou.Speed = new Vector2( bignou.Speed.X,  bignou.Speed.Y + batLeft.Speed.Y);
                        }
                    }
                }
                else if (bignou.BoundingRect.Contains((int)batLeft.Position.X + batLeft.Size.Width, (int)batLeft.Position.Y + batLeft.Size.Height) ||
                            bignou.BoundingRect.Contains((int)batLeft.Position.X, (int)batLeft.Position.Y + batLeft.Size.Height))
                {
                    if (X > Y)
                    {
                        if (bignou.Speed.Y <= 0)
                        {
                            bignou.Speed = new Vector2(bignou.Speed.X + batLeft.Speed.X * (float)0.5, Math.Max(-bignou.Speed.Y, batLeft.Speed.Y));
                            //_ballBounceWall.Play();
                        }
                        else if (batLeft.Speed.Y > 0)
                        {
                            bignou.Speed = new Vector2( bignou.Speed.X,  bignou.Speed.Y + batLeft.Speed.Y);
                        }
                    }
                }
                

                /************************************************************************************************************************************************
                *                                                       Logic collision raquette droite
                ************************************************************************************************************************************************/

                float Y2 = Math.Min(Math.Min(Math.Max(bignou.Position.Y + bignou.Size.Height - batRight.Position.Y, 0), Math.Max(batRight.Position.Y + batRight.Size.Height - bignou.Position.Y, 0)), bignou.Size.Height);
                float X2 = Math.Min(Math.Min(Math.Max(bignou.Position.X + bignou.Size.Width - batRight.Position.X, 0), Math.Max(batRight.Position.X + batRight.Size.Width - bignou.Position.X, 0)), bignou.Size.Width);

                if (batRight.BoundingRect.Contains((int)bignou.Position.X + bignou.Size.Width, (int)bignou.Position.Y) ||
                    batRight.BoundingRect.Contains((int)bignou.Position.X + bignou.Size.Width, (int)bignou.Position.Y + bignou.Size.Height))
                {
                    if (X2 < Y2)
                    {
                        if (bignou.Speed.X >= 0)
                        {
                            bignou.Speed = new Vector2(Math.Min(-bignou.Speed.X, batRight.Speed.X), batRight.Speed.Y + batRight.Speed.Y * (float)0.5);
                            //_ballBounceWall.Play();
                        }
                        else if (batRight.Speed.X < 0)
                        {
                            bignou.Position = new Vector2(bignou.Position.X + batRight.Speed.X, bignou.Position.Y);
                        }
                    }
                }
                else if (batRight.BoundingRect.Contains((int)bignou.Position.X, (int)bignou.Position.Y) ||
                        batRight.BoundingRect.Contains((int)bignou.Position.X, (int)bignou.Position.Y + bignou.Size.Height))
                {
                    if (X2 < Y2)
                    {
                        if (bignou.Speed.X <= 0)
                        {
                            bignou.Speed = new Vector2(Math.Max(-bignou.Speed.X, batRight.Speed.X), bignou.Speed.Y + batRight.Speed.Y * (float)0.5);
                            //_ballBounceWall.Play();
                        }
                        else if (batRight.Speed.X > 0)
                        {
                            bignou.Speed = new Vector2(bignou.Speed.X + batRight.Speed.X, bignou.Speed.Y);
                        }
                    }
                }

                if (bignou.BoundingRect.Contains((int)batRight.Position.X, (int)batRight.Position.Y) ||
                         bignou.BoundingRect.Contains((int)batRight.Position.X + batRight.Size.Width, (int)batRight.Position.Y))
                {
                    if (X2 > Y2)
                    {
                        if (bignou.Speed.Y >= 0)
                        {
                            bignou.Speed = new Vector2(bignou.Speed.X + batRight.Speed.X * (float)0.5, bignou.Speed.Y + Math.Min(-bignou.Speed.Y, batRight.Speed.Y));
                            //_ballBounceWall.Play();
                        }
                        else if (batRight.Speed.Y < 0)
                        {
                            bignou.Speed = new Vector2(bignou.Speed.X, bignou.Speed.Y + batRight.Speed.Y);
                        }
                    }
                }
                else if (bignou.BoundingRect.Contains((int)batRight.Position.X + batRight.Size.Width, (int)batRight.Position.Y + batRight.Size.Height) ||
                        bignou.BoundingRect.Contains((int)batRight.Position.X, (int)batRight.Position.Y + batRight.Size.Height))
                {
                    if (X2 > Y2)
                    {
                        if (bignou.Speed.Y <= 0)
                        {
                            bignou.Speed = new Vector2(bignou.Speed.X + batRight.Speed.X * (float)0.5, Math.Max(-bignou.Speed.Y, batLeft.Speed.Y));
                            //_ballBounceWall.Play();
                        }
                        else if (batRight.Position.Y > 0)
                        {
                            bignou.Speed = new Vector2(bignou.Speed.X, bignou.Speed.Y + batRight.Speed.Y);
                        }
                    }
                }

                /**
                 * Bignou slowing
                 */
                double speedReductionFactor = 0.997;
                bignou.Speed *= (float)speedReductionFactor;
            }
        }
    }
}
