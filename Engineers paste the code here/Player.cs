using GXPEngine;
using System;

public class Player : AnimationSprite
{
    float speedX;
    float speedY;
    int _score;
    int health;
    

    public Player() : base("character.png", 80, 1)
    {
        SetOrigin(width/2, height/2);
        scale = 3;
        speedX = 0.0f;
        speedY = 0.0f;
        health = 3;
        PlayerSpawn();
    }

    public void Update()
    {
        Movement();
        IsPlayerAlive();
        Console.WriteLine(health);
       
    }
    public int GetScore() { return _score; }

    void PlayerSpawn()
    {
        x = game.width/2;
        y = game.height/2;
        health = 3;

    }

     void Movement()
    {
        
        
        if(Input.GetKey(Key.W))
        {
            speedY = speedY - 1.0f;
            SetCycle(0);
           
            
        }
        if (Input.GetKey(Key.S))
        {
            speedY = speedY + 1.0f;
            
            SetCycle(0, 1);
        }
        if (Input.GetKey(Key.A))
        {
            speedX = speedX - 1.0f;
           
            SetCycle(0, 1);

        }
        if (Input.GetKey(Key.D))
        {
            speedX = speedX + 1.0f;
            
            SetCycle(0, 1);
        }
        else { SetCycle(0, 1); }
        x = x + speedX;
        y = y + speedY;
        speedX = speedX * 0.9f;
        speedY = speedY * 0.9f;


        Animate(0.1f);

       
    }

    void IsPlayerAlive()
    {
        if(health <1)
        {
            
            PlayerSpawn();
            Console.WriteLine("dead");
        } 
    }

   



    void OnCollision(GameObject other)
    {
        if(other is Enemy)
        {
            Enemy enemy = (Enemy)other;
            speedX = 0.0f;
            speedY = 0.0f;
            health=health-1;
            enemy.EnemyGone();

        }
    }

}


















