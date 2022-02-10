using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GXPEngine;

namespace GXPEngine
{
    public class UserInterface : EasyDraw
    {
        static int screenX = 1280;
        static int screenY = 720;
        int offsetX = 720 / 2;
        int offsetY = 720 / 2;
        string spriteHearts = "reference to heart here";

        public UserInterface() : base(screenX, screenY)
        {
            // Placeholder screen
            Fill(Color.LawnGreen);
            Rect(280 + offsetX, 0 + offsetY, 720, 720);

            // Placeholder UI elements

            // Text
            Fill(Color.White);
            TextSize(30f);
            TextAlign(CenterMode.Center, CenterMode.Center);
            TextFont("Verdana", 30f, FontStyle.Bold);
            Text("SCORE:", 1140, 150); // Text score letters
            Text("00000", 1140, 200); // Text score numbers
            Text("WAVE: 1", 140, 300);

            // Hearts
            Fill(Color.Red);
            Rect(90, 150, 50, 50);
            Text("x 3", 170, 150);

            // Circles

            for (int i = 0; i < 7; i++)
            {
                if (i == 0 || i == 3 || i == 6)
                {
                     Fill(Color.LawnGreen);
                     Ellipse(140, 390 + (i * 40), 50, 50);
                }
                else
                {
                    Fill(Color.Beige);
                    Ellipse(140, 390 + (i * 40), 15, 15);
                }
            }



        }	
	}
}
