using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Threading;
using System.Windows.Media.Imaging;

namespace CreatureKingdom
{
    class CallahanNathanielCreature : Creature
    {
        //Canvas kingdom;
        Image creatureImage;
        BitmapImage leftBitmap;
        BitmapImage rightBitmap;
        double kingdomWidth = 0.0;
        double creatureWidth = 100.0;
        double maxX = 0.0;
        double maxY = 0.0;
        double incrementSize = 5.0;

        private Int32 waitTime;
        private Boolean goRight = true;
        private Thread posnThread = null;
        public CallahanNathanielCreature(Canvas kingdom, Dispatcher dispatcher, Int32 time = 100) : base(kingdom, dispatcher, time)
        {
            //this will randomize the speed of the creature
            //Random random = new Random();
            //this.incrementSize = random.Next(2,25);
            this.kingdom = kingdom;
            this.dispatcher = dispatcher;
            this.waitTime = time;
            kingdomWidth = (int)this.kingdom.Width;
            maxX = kingdomWidth - creatureWidth;

            creatureImage = new Image();
            creatureImage.Width = creatureWidth;

            leftBitmap = LoadBitmap(@"CallahanNathaniel\left.png", 100);
            rightBitmap = LoadBitmap(@"CallahanNathaniel\right.png", 100);
        }

        //don't need this since it's in the base class
        //private BitmapImage LoadBitmap(String imageFile)
        //{
        //    BitmapImage theBitmap = new BitmapImage();
        //    theBitmap.BeginInit();
        //    string path = System.IO.Path.Combine(Environment.CurrentDirectory, imageFile);
        //    theBitmap.UriSource = new Uri(path, UriKind.Absolute);
        //    theBitmap.DecodePixelWidth = (int)creatureWidth;
        //    theBitmap.EndInit();

        //    return theBitmap;
        //}

        public override void Place(double x = 100.0, double y = 200.0)
        {
            String direction = "right";
            switch (direction)
            {
                case "right":
                    {
                        creatureImage.Source = rightBitmap;
                        goRight = true;
                        break;
                    }
                case "left":
                    {
                        creatureImage.Source = leftBitmap;
                        goRight = false;
                        break;
                    }
                default:
                    {
                        creatureImage.Source = rightBitmap;
                        goRight = true;
                        break;
                    }
            }

            this.x = x;
            this.y = y;
            kingdom.Children.Add(creatureImage);
            creatureImage.SetValue(Canvas.LeftProperty, this.x);
            creatureImage.SetValue(Canvas.TopProperty, this.y);

            posnThread = new Thread(Position);

            posnThread.Start();
        }

        void Position()
        {
            while (true)
            {
                if (!this.Paused)
                {
                    maxX = kingdom.ActualWidth - creatureWidth;
                    if (goRight)
                    {
                        x += incrementSize;

                        if (x > maxX)
                        {
                            x = maxX;
                            goRight = false;
                            SwitchBitmap(leftBitmap);
                        }
                    }
                    else
                    {
                        x -= incrementSize;

                        if (x < 0)
                        {
                            goRight = true;
                            SwitchBitmap(rightBitmap);
                        }
                    }

                    UpdatePosition();
                    Thread.Sleep(waitTime);
                }
            }
        }

        void UpdatePosition()
        {
            Action action = () => { creatureImage.SetValue(Canvas.LeftProperty, x); creatureImage.SetValue(Canvas.TopProperty, y); };
            dispatcher.BeginInvoke(action);
        }

        void SwitchBitmap(BitmapImage theBitmap)
        {
            Action action = () => { creatureImage.Source = theBitmap; };
            dispatcher.BeginInvoke(action);
        }

        public override void Shutdown()
        {
            if (posnThread != null)
            {
                posnThread.Abort();
            }
        }
    }
}
