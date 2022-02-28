using System;
using GXPEngine;

public class EnemyVenusFlytrap : AnimationSprite
{
  public  float speedX;
  public  float speedY;
    int healthVenusFlytrap;
    float animationSpeed = 0.05f;
    UserInterface _userInterface;
    
    public EnemyVenusFlytrap() : base("VenusFlytrap.png", 7, 1)
    {
        SetOrigin(width/2,height/2);
        speedX = 1.0f;
        speedY = 1.0f;
        healthVenusFlytrap = 1;

        _userInterface = game.FindObjectOfType<UserInterface>();
    }

    void health()
    {
        if (healthVenusFlytrap <= 0)
            {
                EnemyVenusFlytrapGone();
            }
    }

    public void EnemyVenusFlytrapGone()
    {

        this.LateDestroy();
        _userInterface.score += 10;
    }
    void Update()
    {
        EnemyVenusFlytrapAnimator();
        FindPlayer();
    }

    void EnemyVenusFlytrapAnimator()
    {
        SetCycle(0, 7);
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