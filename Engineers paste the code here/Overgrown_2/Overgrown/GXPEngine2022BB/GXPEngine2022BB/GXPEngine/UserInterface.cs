using System.Drawing;

namespace GXPEngine
{
    public class UserInterface : EasyDraw
    {
        static int screenX = 1280;
        static int screenY = 720;
        int offsetX = 720 / 2;
        int offsetY = 720 / 2;
        string spriteHearts = "reference to heart here";
        public int waveHeight = 1;

        private Level _level;
        private Player _player;

        float timeLevel = 30;
        float currentTime;

        float waveAddTime = 5;
        float waveDifference = 0;

        float timer;

        public int score;

        // Vars for wave time
        float actualWaveTime;
        float waveStartTime;
        int waveNumber = 1;
        int lastWaveNumber = 1;

        public UserInterface() : base(screenX, screenY)
        {

        }



        void Text()
        {
            // Text

            graphics.Clear(Color.Empty);

            Fill(Color.White);
            TextSize(30f);
            TextAlign(CenterMode.Center, CenterMode.Center);
            TextFont("Verdana", 30f, FontStyle.Bold);

            Text("SCORE:", 1140, 125); // Text score letters
            Text(score + "", 1140, 175); // Text score numbers
            Text("WAVE: " + _level.getWave(), 140, 300); // Wave number

            // Hearts
            Fill(Color.Red);
            PlayerHead lives = new PlayerHead();
            lives.x = 1095;
            lives.y = 300;
            lives.scale = 1.5f;
            DrawSprite(lives);

            Text("x" + _player.health, 1175, 300);

            // Circles
            for (int i = 0; i < 7; i++)
            {
                if (i == 0 || i == 3 || i == 6)
                {
                    Fill(Color.LawnGreen);
                    Ellipse(140, 390 + (i * 40), 50, 50);
                }
                else
                {
                    Fill(Color.Beige);
                    Ellipse(140, 390 + (i * 40), 15, 15);
                }
            }
        }
        void Timer()
        {
            if (_level.getWave() - waveDifference >= waveAddTime)
            {
                timeLevel += 10;
                waveDifference = _level.getWave();
            }

            if (timer >= 0)
            {
                timer = timeLevel - actualWaveTime;
                if (timer < 0)
                {
                    timer = 0;
                }

                Fill(Color.White);
                TextSize(30f);
                TextAlign(CenterMode.Center, CenterMode.Center);
                TextFont("Verdana", 20f, FontStyle.Bold);
                Text("Time: " + timer + " seconds", 150, 150);

            }
        }

        

        void Update()
        {
            // Sets time
            currentTime = Time.time / 1000;

            if (_level == null)
            {
                _level = game.FindObjectOfType<Level>();
            }
            if (_player == null)
            {
                _player = parent.FindObjectOfType<Player>();
            }


            Text();
            Timer();
            SetActualWaveTime();
        }

        public float getTime()
        {
            return actualWaveTime;
        }

        void SetActualWaveTime()
        {
            actualWaveTime = currentTime - waveStartTime;
            waveNumber = _level.getWave();

            if (waveNumber > lastWaveNumber)
            {
                waveStartTime = currentTime;
                actualWaveTime = currentTime - waveStartTime;
                _level.spawnTime = actualWaveTime + _level.delay;
            }

            lastWaveNumber = waveNumber;
        }
    }
}
