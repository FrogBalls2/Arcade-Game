using System;
using GXPEngine;
using System.Drawing;

public class HUD : Canvas
{
    
    private Player _player;


    public HUD(Player player) : base(500,300)
    {
        _player = player;
        
    }
    void Update()
    {
        this.scale = 2;
        graphics.Clear(Color.Empty);
        graphics.DrawString("SCORE:" + _player.GetScore(), SystemFonts.StatusFont, Brushes.White, 0, 10);
    }
}