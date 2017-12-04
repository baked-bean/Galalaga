using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Galalalaga
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D playerSprite;
        playerShip player;

        Texture2D[] enemySprite;
        //time allowing
        
        
        enemyShip[] enemies;
        Vector2[,] enemyGrid;
        
        Keys[] pressedKeys;

        //game objects/variables
        KeyboardState currentState;
        float speed;
        int timer;
        float[] screenDim;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            player = new playerShip();
            enemySprite = new Texture2D[3];
            
            enemies = new enemyShip[25];
            enemyGrid = new Vector2[5,5];
             
            screenDim = new float[]{GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height};

            //initializes the array of positions
            float holdX = 0;
            float holdY = 0;
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    holdX += (screenDim[0] / 5);
                    enemyGrid[x,y] = new Vector2(holdX, holdY);
                }
                holdX = 0;
                holdY += (10 + (50 * (x+1)));
            }

            int currentShip = 0;
                //assigns positions to ships and makes them idle
                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 5; y++)
                    {
                        enemies[currentShip] = new enemyShip(enemyGrid[x, y], enemySprite[0]);
                        enemies[currentShip].setStance(enemyShip.stance.idling);
 
                        currentShip += 1;
                    }
                }


          

            speed = 5;
            timer = 0;

            player.setPlayerPos(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height - 60);




            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            enemySprite[0] = Content.Load<Texture2D>("enemyRed");
            playerSprite = Content.Load<Texture2D>("ship");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            timer += 1;

            currentState =  Keyboard.GetState();
            pressedKeys = currentState.GetPressedKeys();
            enemies[0] = new enemyShip(enemyGrid[2,4],enemySprite[0]);

         
            if (pressedKeys.Length != 0)
            {
                switch (pressedKeys[pressedKeys.Length - 1])
                {

                    case Keys.D:
                        player.setPlayerPos(player.getPlayerPos().X + speed, player.getPlayerPos().Y);
                        break;
                    case Keys.A:
                        player.setPlayerPos(player.getPlayerPos().X - speed, player.getPlayerPos().Y);
                        break;
                    case Keys.Space:
                        
                        break;
                }
                //Check to make sure the user didn't overstep his damn bounds
            }
            // TODO: Add your update logic here
           
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            
            //hopefully this looks like

            spriteBatch.Draw(playerSprite, player.getPlayerRect(), Color.White);
            //loop
            //draw(enemys[x],pos[])
            //endloop
            
            for (int x = 0; x < 25; x++)
            {
                spriteBatch.Draw(
                enemies[x].getTexture(),
                enemies[x].getRect(),
                Color.White);
            }
            
#help
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
