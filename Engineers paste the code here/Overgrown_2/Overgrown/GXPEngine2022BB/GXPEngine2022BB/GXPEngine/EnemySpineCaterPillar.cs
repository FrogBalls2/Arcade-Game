using System;
using GXPEngine;

public class EnemySpineCaterPillar : AnimationSprite
{
  public  float speedX;
  public  float speedY;
    int healthSpineCaterPillar;
    float animationSpeed = 0.05f;

    UserInterface _userInterface;
    
    public EnemySpineCaterPillar() : base("SpineCaterPillar.png", 4, 1)
    {
        SetOrigin(width/2,height/2);
        speedX = 1.0f;
        speedY = 1.0f;
        healthSpineCaterPillar = 1;

        _userInterface = game.FindObjectOfType<UserInterface>();
    }

    void health()
    {
        if (healthSpineCaterPillar <= 0)
        {
            EnemySpineCaterPillarGone();
        }
    }

    public void EnemySpineCaterPillarGone()
    {
        
        this.LateDestroy();
        _userInterface.score += 15;
        
    }
    void Update()
    {
        EnemySpineCaterPillarAnimator();
        FindPlayer();
    }

    void EnemySpineCaterPillarAnimator()
    {
        SetCycle(0, 4);
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