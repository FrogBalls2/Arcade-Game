using System;									
using GXPEngine;                                
using System.Drawing;							

public class MyGame : Game
{
	Menu menu;
	public MyGame() : base(1280, 720, false)		
	{
		// UI class

		
		menu= new Menu();
		AddChild(menu);
		//Level level;
		//level = new Level();
		//AddChild(level);/////////////////////////////////////////////////////

	}

	// For every game object, Update is called every frame, by the engine:
	void Update()
	{
		//getRidOfMenu();
	}

	static void Main()							
	{
		new MyGame().Start();
	}
	public void getRidOfMenu()
    {
        if (menu.isMenuNeeded == false) {menu.visible = false; }
    }
}