using GXPEngine;
using System;

public class Player : AnimationSprite
{
    float speedX;
    float speedY;
    float playerSpeed = 0.6f;
    int _score;
    public int health;
    float sizeChar = 0.4f;
    float animationSpeed = 0.05f;
    float currentTime;
    bool isSlowed = false;
    float slownessTime = 1.0f;
    float slownessTimeSave;

    bool lookingUp;
    bool lookingDown;
    bool lookingRight;
    bool lookingLeft;




    UserInterface _userInterface;

    public Player() : base("Character_Prototype_Spritesheet.png", 16, 1)
    {
        SetOrigin(width / 2, height / 2);
        scale = 3;
        speedX = 0.0f;
        speedY = 0.0f;
        health = 3;
        PlayerSpawn();
    }

    void Update()
    {
        if (_userInterface == null)
        {
            _userInterface = parent.FindObjectOfType<UserInterface>();
        }
        if (_userInterface != null)
        {
            Console.WriteLine("Banaan");
        }
        Movement();
        IsPlayerAlive();
        Console.WriteLine(health);
        SlownessTimer();
        WeaponAttack();
    }

    void SlownessTimer()
    {
        if (_userInterface != null)
        {
            currentTime = _userInterface.getTime();
        }

        if (isSlowed)
        {
            playerSpeed = 0.05f;
            if (currentTime - slownessTimeSave >= slownessTime)
            {
                playerSpeed = 0.15f;
                isSlowed = false;
            }
        }
    }

    public int GetScore()
    {
        return _score;
    }

    void PlayerSpawn()
    {
        x = game.width / 2;
        y = game.height / 2;
        health = 3;
        scale = sizeChar;
    }

    void Movement()
    {


        if (Input.GetKey(Key.W))
        {
            speedY = speedY - playerSpeed;
            SetCycle(4, 2);
            lookingUp = true;
            lookingDown = false;
            lookingLeft = false;
            lookingRight = false;


        }
        if (Input.GetKey(Key.S))
        {
            speedY = speedY + playerSpeed;
            SetCycle(2, 2);
            lookingUp = false;
            lookingDown = true;
            lookingLeft = false;
            lookingRight = false;
        }
        if (Input.GetKey(Key.A))
        {
            speedX = speedX - playerSpeed;

            SetCycle(11, 5);
            lookingUp = false;
            lookingDown = false;
            lookingLeft = true;
            lookingRight = false;

        }
        if (Input.GetKey(Key.D))
        {
            speedX = speedX + playerSpeed;

            SetCycle(6, 5);
            lookingUp = false;
            lookingDown = false;
            lookingLeft = false;
            lookingRight = true;
        }
        if (!Input.GetKey(Key.D) && !Input.GetKey(Key.W) && !Input.GetKey(Key.A) && !Input.GetKey(Key.S)) { SetCycle(0, 2); }
        x = x + speedX;
        y = y + speedY;
        speedX = speedX * 0.9f;
        speedY = speedY * 0.9f;

        Animate(animationSpeed);
    }

    void IsPlayerAlive()
    {
        if (health < 1)
        {

            PlayerSpawn();
            Console.WriteLine("dead");
        }
    }
    public void WeaponAttack()
    {
        if (Input.GetKeyDown(Key.E))
        {
            
            

                if (lookingUp)
                {
                    Weapon weapon = new Weapon(this.x, this.y -100);
                    AddChild(weapon);
                    weapon.scale = 2;
                    weapon.speedY = weapon.speedY - weapon.speed;
                }
                if (lookingDown)
                {
                    Weapon weapon = new Weapon(this.x, this.y + 100);
                    AddChild(weapon);
                    weapon.scale = 2;
                    weapon.speedY = weapon.speedY + weapon.speed;
                }
                if (lookingLeft)
                {
                    Weapon weapon = new Weapon(this.x-100, this.y);
                    AddChild(weapon);
                    weapon.scale = 2;
                    weapon.speedX = weapon.speedX - weapon.speed;
                }
                if (lookingRight)
                {
                    Weapon weapon = new Weapon(this.x+100, this.y);
                    AddChild(weapon);
                    weapon.scale = 2;
                    weapon.speedX = weapon.speedX + weapon.speed;
                }


            
        }


    }
    void OnCollision(GameObject other)
    {
        if (other is EnemyVenusFlytrap)
        {
            EnemyVenusFlytrap enemyVenusFlytrap = (EnemyVenusFlytrap)other;
            speedX = 0.0f;
            speedY = 0.0f;
            health--;


            enemyVenusFlytrap.EnemyVenusFlytrapGone();
        }
        if (other is EnemySpineCaterPillar)
        {
            EnemySpineCaterPillar enemySpineCaterPillar = (EnemySpineCaterPillar)other;
            speedX = 0.0f;
            speedY = 0.0f;
            health--;

            enemySpineCaterPillar.EnemySpineCaterPillarGone();
        }
        if (other is EnemyMushroom)
        {
            EnemyMushroom enemyMushroom = (EnemyMushroom)other;
            speedX = 0.0f;
            speedY = 0.0f;
            health--;

            enemyMushroom.EnemyMushroomGone();
        }
        if (other is SlownessTile)
        {
            isSlowed = true;
            slownessTimeSave = currentTime;
        }
        if (other is Tree)
        {
            speedX = 0f;
            speedY = 0f;
        }
    }

}


















