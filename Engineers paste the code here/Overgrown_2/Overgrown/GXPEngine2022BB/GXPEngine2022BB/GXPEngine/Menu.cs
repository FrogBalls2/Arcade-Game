using System;
using GXPEngine;
using System.Drawing;

public class Menu : EasyDraw
{
    static int screenX = 1280;
    static int screenY = 720;
    bool _hasStarted = false;
    bool canStart = true;
    public bool isMenuNeeded = true;

    //Player _player;
    public Menu() : base(screenX, screenY)
    {

    }
    
   public void Title()
    {
        if (_hasStarted == false && canStart == true)  //if tihs hasnt happened and it can it will do it
        {
            graphics.Clear(Color.Empty);
            Fill(Color.LightGreen);
            TextSize(80f);
            TextAlign(CenterMode.Center, CenterMode.Center);
            TextFont("Verdana", 100f, FontStyle.Bold);
            Text("OVERGROWN", game.width / 2, game.height / 10);
            
            TextFont("Verdana", 50f, FontStyle.Bold);
            Text("PRESS E TO START", game.width / 2, game.height - game.height / 3);
        }
        else{ Console.WriteLine("there is no text :("); }
        
       
           

    }
   
    void Update()
    {
        if (Input.GetKeyDown(Key.E) && canStart == true)
        {
            StartGame();
            _hasStarted = true;
            
        }

        if (isMenuNeeded) { Title(); }
        
    }

    
    public void StartGame()
    {
        if (_hasStarted == true)
        {
           isMenuNeeded = false;
            Level level = new Level();
            level.visible = true;
            AddChild(level);
            


            canStart = false;
            Console.WriteLine("starting");
        }

    }

}
