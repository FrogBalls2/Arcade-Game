using GXPEngine;
using System.Collections.Generic;
using System;

public class Level : GameObject
{

    List<Grass> grassTiles;
    List<Grass> spawnTiles;
    public List<EnemyVenusFlytrap> enemies;
    public List<EnemySpineCaterPillar> enemies1;
    public List<EnemyMushroom> enemies2;

    UserInterface _userInterface;

    //timer
    public float spawnTime;
    public float delay = 2;
    float currentTime;
    float delayDecrease = 0.05f; // each wave the delay of the enemy spawn decreases
    bool nextWaveActivate = false;
    bool enemyHasStopped;
    float speedEnemy = 0.05f;

    int nextWave_ = 1;

    Random rnd = new Random();
    
    const int WIDTH = 23;
    const int HEIGHT = 40;
    const int SIZE = 32;

    public EnemyVenusFlytrap enemy;
    public EnemySpineCaterPillar enemy1;
    public EnemyMushroom enemy2;
    public Player player;

    void Timer()
    {
        currentTime = _userInterface.getTime();

        if (currentTime >= spawnTime)
        {
            int randomEnemy = rnd.Next(0, 3);
            int randomNumber = rnd.Next(0, spawnTiles.Count);
            Grass selectedTile = spawnTiles[randomNumber];
            if (randomEnemy == 0)
            {
                enemy = new EnemyVenusFlytrap();
                enemy.x = selectedTile.x;
                enemy.y = selectedTile.y;
                AddChild(enemy);
                enemies.Add(enemy);
                Console.WriteLine(enemy);
            }
            if (randomEnemy == 1)
            {
                enemy1 = new EnemySpineCaterPillar();
                enemy1.x = selectedTile.x;
                enemy1.y = selectedTile.y;
                AddChild(enemy1);
                enemies1.Add(enemy1);
                Console.WriteLine(enemy1);
            }
            if (randomEnemy == 2)
            {
                enemy2 = new EnemyMushroom();
                enemy2.x = selectedTile.x;
                enemy2.y = selectedTile.y;
                AddChild(enemy2);
                enemies2.Add(enemy2);
                Console.WriteLine(enemy2);
            }
            spawnTime = currentTime + delay;
        }
    }

    void GoToPlayer()
    {
        foreach (EnemyVenusFlytrap enemy in enemies)
        {
            if (enemy.x < player.x)
            {
                enemy.x += speedEnemy * Time.deltaTime;
                enemyHasStopped = false;
            }
            if (enemy.x > player.x)
            {
                enemy.x -= speedEnemy * Time.deltaTime;
                enemyHasStopped = false;
            }
            if (enemy.y < player.y)
            {
                enemy.y += speedEnemy * Time.deltaTime;
                enemyHasStopped = false;
            }
            if (enemy.y > player.y)
            {
                enemy.y -= speedEnemy * Time.deltaTime;
                enemyHasStopped = false;
            }
        }

        foreach (EnemySpineCaterPillar enemy1 in enemies1)
        {
            if (enemy1.x < player.x)
            {
                enemy1.x += speedEnemy * Time.deltaTime;
                enemyHasStopped = false;
            }
            if (enemy1.x > player.x)
            {
                enemy1.x -= speedEnemy * Time.deltaTime;
                enemyHasStopped = false;
            }
            if (enemy1.y < player.y)
            {
                enemy1.y += speedEnemy * Time.deltaTime;
                enemyHasStopped = false;
            }
            if (enemy1.y > player.y)
            {
                enemy1.y -= speedEnemy * Time.deltaTime;
                enemyHasStopped = false;
            }
        }
        foreach (EnemyMushroom enemy2 in enemies2)
        {
            if (enemy2.x < player.x)
            {
                enemy2.x += speedEnemy * Time.deltaTime;
                enemyHasStopped = false;
            }
            if (enemy2.x > player.x)
            {
                enemy2.x -= speedEnemy * Time.deltaTime;
                enemyHasStopped = false;
            }
            if (enemy2.y < player.y)
            {
                enemy2.y += speedEnemy * Time.deltaTime;
                enemyHasStopped = false;
            }
            if (enemy2.y > player.y)
            {
                enemy2.y -= speedEnemy * Time.deltaTime;
                enemyHasStopped = false;
            }
        }
    }

    int[,] level = new int[WIDTH, HEIGHT]
    {
     {0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,4,5,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0 },
     {0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,4,5,2,2,2,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0 },
     {0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,6,6,2,2,2,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0 },
     {0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0 },
     {0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0 },
     {0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0 },
     {0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0 },
     {0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0 },
     {0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0 },
     {0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0 },
     {0,0,0,0,0,0,0,0,0,0,8,8,10,2,2,2,2,2,2,2,2,2,2,2,2,2,2,12,14,14,0,0,0,0,0,0,0,0,0,0 },
     {0,0,0,0,0,0,0,0,0,0,9,9,11,2,2,2,2,2,2,2,2,2,2,2,2,2,2,13,15,15,0,0,0,0,0,0,0,0,0,0 },
     {0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0 },
     {0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0 },
     {0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0 },
     {0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0 },
     {0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0 },
     {0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0 },
     {0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0 },
     {0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0 },
     {0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,16,17,2,2,2,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0 },
     {0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,18,19,2,2,2,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0 },
     {0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,18,19,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0 },

    };

    public Level()
    {
        
        spawnTiles = new List<Grass>();
        enemies = new List<EnemyVenusFlytrap>();
        enemies1 = new List<EnemySpineCaterPillar>();
        enemies2 = new List<EnemyMushroom>();
        grassTiles = new List<Grass>();
        // Player player = new Player();
        //AddChild(player);
        //HUD hud = new HUD(player);
        // AddChild(hud);

        for (int row = 0; row < WIDTH; row++)
        {
            for (int col = 0; col < HEIGHT; col++)
            {
                int tile = level[row, col];
                createTile(row, col, tile);
            }
        }
        PlaceSlownessTiles();
        player = new Player();
        AddChild(player);
        _userInterface = new UserInterface();
        AddChild(_userInterface);

    }

    void createTile(int row, int col, int tile)
    {
        
        switch (tile)
        {
            case 1:
                Tree tree = new Tree();
                AddChild(tree);
                tree.x = col * SIZE;
                tree.y = row * SIZE;
                break;

            case 2:
                Grass grass = new Grass();
                grassTiles.Add(grass);
                AddChild(grass);
                grass.x = col * SIZE;
                grass.y = row * SIZE;
                break;

            case 3:
                break;

            case 4:

                Grass grassSpawn = new Grass();
                spawnTiles.Add(grassSpawn);
                grassSpawn.x = col * SIZE;
                grassSpawn.y = row * SIZE;

                Grass1 grassSpawn1 = new Grass1();
                grassSpawn1.x = col * SIZE;
                grassSpawn1.y = row * SIZE;
                AddChild(grassSpawn1);

                break;

            case 5:
                Grass grassSpawn_1 = new Grass();
                spawnTiles.Add(grassSpawn_1);
                grassSpawn_1.x = col * SIZE;
                grassSpawn_1.y = row * SIZE;
                AddChild(grassSpawn_1);

                Grass2 grassSpawn2 = new Grass2();
                grassSpawn2.x = col * SIZE;
                grassSpawn2.y = row * SIZE;
                AddChild(grassSpawn2);
                break;

             case 6:

                Grass3 grassSpawn3 = new Grass3();
                grassSpawn3.x = col * SIZE;
                grassSpawn3.y = row * SIZE;
                AddChild(grassSpawn3);
                break;

            case 7:
                Grass grassSpawn_3 = new Grass();
                spawnTiles.Add(grassSpawn_3);
                grassSpawn_3.x = col * SIZE;
                grassSpawn_3.y = row * SIZE;
                AddChild(grassSpawn_3);

                Grass4 grassSpawn4 = new Grass4();
                grassSpawn4.x = col * SIZE;
                grassSpawn4.y = col * SIZE;
                AddChild(grassSpawn4);
                break;

            case 8:
                
                Grass grassSpawn_4 = new Grass();
                spawnTiles.Add(grassSpawn_4);
                grassSpawn_4.x = col * SIZE;
                grassSpawn_4.y = row * SIZE;
                AddChild(grassSpawn_4);

                Grass5 grassSpawn5 = new Grass5();
                grassSpawn5.x = col * SIZE;
                grassSpawn5.y = row * SIZE;
                AddChild(grassSpawn5);
                break;
                
            case 9:
                Grass grassSpawn_5 = new Grass();
                spawnTiles.Add(grassSpawn_5);
                grassSpawn_5.x = col * SIZE;
                grassSpawn_5.y = row * SIZE;
                AddChild(grassSpawn_5);

                Grass6 grassSpawn6 = new Grass6();
                grassSpawn6.x = col * SIZE;
                grassSpawn6.y = row * SIZE;
                AddChild(grassSpawn6);
                break;

            case 10:

                Grass7 grassSpawn7 = new Grass7();
                grassSpawn7.x = col * SIZE;
                grassSpawn7.y = row * SIZE;
                AddChild(grassSpawn7);
                break;

            case 11:

                Grass8 grassSpawn8 = new Grass8();
                grassSpawn8.x = col * SIZE;
                grassSpawn8.y = row * SIZE;
                AddChild(grassSpawn8);
                break;

            case 12:

                Grass9 grassSpawn9 = new Grass9();
                grassSpawn9.x = col * SIZE;
                grassSpawn9.y = row * SIZE;
                AddChild(grassSpawn9);
                break;

            case 13:

                Grass10 grassSpawn10 = new Grass10();
                grassSpawn10.x = col * SIZE;
                grassSpawn10.y = row * SIZE;
                AddChild(grassSpawn10);
                break;

            case 14:
                Grass grassSpawn_10 = new Grass();
                spawnTiles.Add(grassSpawn_10);
                grassSpawn_10.x = col * SIZE;
                grassSpawn_10.y = row * SIZE;
                AddChild(grassSpawn_10);

                Grass11 grassSpawn11 = new Grass11();
                grassSpawn11.x = col * SIZE;
                grassSpawn11.y = row * SIZE;
                AddChild(grassSpawn11);
                break;

            case 15:
                Grass grassSpawn_11 = new Grass();
                spawnTiles.Add(grassSpawn_11);
                grassSpawn_11.x = col * SIZE;
                grassSpawn_11.y = row * SIZE;
                AddChild(grassSpawn_11);

                Grass12 grassSpawn12 = new Grass12();
                grassSpawn12.x = col * SIZE;
                grassSpawn12.y = row * SIZE;
                AddChild(grassSpawn12);
                break;

            case 16:

                Grass13 grassSpawn13 = new Grass13();
                grassSpawn13.x = col * SIZE;
                grassSpawn13.y = row * SIZE;
                AddChild(grassSpawn13);
                break;

            case 17:

                Grass14 grassSpawn14 = new Grass14();
                grassSpawn14.x = col * SIZE;
                grassSpawn14.y = row * SIZE;
                AddChild(grassSpawn14);
                break;

            case 18:
                Grass grassSpawn_14 = new Grass();
                spawnTiles.Add(grassSpawn_14);
                grassSpawn_14.x = col * SIZE;
                grassSpawn_14.y = row * SIZE;
                AddChild(grassSpawn_14);

                Grass15 grassSpawn15 = new Grass15();
                grassSpawn15.x = col * SIZE;
                grassSpawn15.y = row * SIZE;
                AddChild(grassSpawn15);
                break;

            case 19:
                Grass grassSpawn_15 = new Grass();
                spawnTiles.Add(grassSpawn_15);
                grassSpawn_15.x = col * SIZE;
                grassSpawn_15.y = row * SIZE;
                AddChild(grassSpawn_15);

                Grass16 grassSpawn16 = new Grass16();
                grassSpawn16.x = col * SIZE;
                grassSpawn16.y = row * SIZE;
                AddChild(grassSpawn16);
                break;
        }
    }

    void waveLength()
    {
       
    }
    void waveUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            nextWaveActivate = true;
            nextWave_ = nextWave_ + 1;
        }
        if (nextWaveActivate && delay >= 0.1f)
        {
            delay -= delayDecrease;
            nextWaveActivate = false;
        }
    }

    void Update()
    {
        player = parent.FindObjectOfType<Player>();
        _userInterface = FindObjectOfType<UserInterface>();
        if (_userInterface == null)
        {
            _userInterface = parent.FindObjectOfType<UserInterface>();
        }
        Timer();
        GoToPlayer();
        waveUpdate();
        Console.WriteLine(enemies.Count);
    }
   
    public int getWave()
    {
        return nextWave_;
    }

     
    void PlaceSlownessTiles()
    {
        int amountOfTiles = rnd.Next(4, 9);
        for (int i = 0; i < amountOfTiles; i++)
        {
            int randomTileIndex = rnd.Next(0, grassTiles.Count);
            Grass selectedTile = grassTiles[randomTileIndex];

            SlownessTile slownessTile = new SlownessTile();
            slownessTile.x = selectedTile.x;
            slownessTile.y = selectedTile.y;
            AddChild(slownessTile);
        }
    }
}

