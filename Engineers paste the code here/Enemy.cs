using System;
using GXPEngine;

public class Enemy : Sprite
{
    float speedX;
    float speedY;
    int health;
    
    public Enemy() : base("circle.png")
    {
        SetOrigin(width/2,height/2);
        speedX = 1.0f;
        speedY = 1.0f;
         health = 1;
        
    }

    public void EnemyGone()
    {
        this.LateDestroy();
    }
    void Update()
    {
        FindPlayer();
    }

    void FindPlayer()
    {
        x = x + speedX;
        y = y + speedY;
        speedX = speedX * 0.9f;
        speedY = speedY * 0.9f;
        
    }
}