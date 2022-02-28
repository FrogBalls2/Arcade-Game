using System;
using GXPEngine;

public class EnemyMushroom : AnimationSprite
{
   public float speedX;
   public float speedY;
    int healthEnemyMushroom;
    float animationSpeed = 0.05f;
    UserInterface _userInterface;
    
    public EnemyMushroom() : base("Mushroom.png", 5, 1)
    {
        SetOrigin(width/2,height/2);
        speedX = 1.0f;
        speedY = 1.0f;
        healthEnemyMushroom = 1;

        _userInterface = game.FindObjectOfType<UserInterface>();
    }

    void health()
    {
        if (healthEnemyMushroom <= 0)
            {
            EnemyMushroomGone();
            }
    }

    public void EnemyMushroomGone()
    {
        _userInterface.score += 20;
        this.LateDestroy();
        
    }
    void Update()
    {
        EnemyMushroomAnimator();
        FindPlayer();
    }

    void EnemyMushroomAnimator()
    {
        SetCycle(0, 5);
        Animate(animationSpeed);
    }


    void FindPlayer()
    {
        x = x + speedX;
        y = y + speedY;
        speedX = speedX * 0.9f;
        speedY = speedY * 0.9f;
    }
    void OnCollision(GameObject other)


    {

        Random rnd = new Random();

        if (other is EnemyMushroom)
        {
            speedX += rnd.Next(-2, 2);
            speedY += rnd.Next(-2, 2);
        }
        if (other is EnemySpineCaterPillar)
        {
            speedX += rnd.Next(-2, 2);
            speedY += rnd.Next(-2, 2);
        }
        if (other is EnemyVenusFlytrap)
        {
            speedX += rnd.Next(-2, 2);
            speedY += rnd.Next(-2, 2);
        }
        if (other is Tree)
        {
            speedX = 0f;
            speedY = 0f;
        }

    }
}