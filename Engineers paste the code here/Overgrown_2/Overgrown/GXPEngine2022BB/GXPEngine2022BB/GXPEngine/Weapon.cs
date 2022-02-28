using System;
using GXPEngine;


public class Weapon : Sprite
{
    Player _player;
    UserInterface _userInterface;

    // time variables
    float currentTime; // Holds current time 
    float delay = 2f; // Delay of holding button
    float buttonPressTime; // Time when button is pressed

    public bool isCharged;
  public float speedX;
  public float speedY;
    public float speed = 0.4f;
    public float x;
    public float y;
    public Weapon (float x, float y) : base("Scythe.png")
    {
        x = x + speedX;
        y = y + speedY;
        x = this.x;
        y = this.y;


    }
    void Update()
    {
        
        if (_player == null)
        {
            _player = parent.FindObjectOfType<Player>();
        }
        if(_userInterface == null)
        {
            _userInterface = parent.FindObjectOfType<UserInterface>();
        }

        
    }

    void Timer()
    {
        currentTime = _userInterface.getTime();
        if (Input.GetKeyDown(Key.E))
        {
            buttonPressTime = currentTime; // Keeps track of when you pressed the button
        }
        if (Input.GetKeyUp(Key.E))
        {
            if (currentTime - buttonPressTime > delay) // If button is held longer than 2 seconds
            {
               // _level.WeaponAttack( );
                isCharged = true;
            }
            else
            {
              //  _level.WeaponAttack();
                isCharged = false;
            }
        }

    }

    
}
