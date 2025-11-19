using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace mono_topic_5_Baddie_class
{
    enum Screen
    {
        Title,
        House,
        End
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        List<Texture2D> boosTextures = new List<Texture2D>();
        List<Rectangle> boosRect = new List<Rectangle>();
        Texture2D backgroundTexture;
        Ghost boos1;

        Texture2D playerTexture;
        Random genorator;
        MouseState mouseState;
        Rectangle window;
        Screen screen; 

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            genorator = new Random();
            window = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            screen = Screen.Title;
            _graphics.ApplyChanges();
            boosTextures.Add(Content.Load<Texture2D>("images/boo-stopped"));
            base.Initialize();

            boos1 = new Ghost(boosTextures, new Vector2(2, 2), new Rectangle(genorator.Next(0, _graphics.PreferredBackBufferWidth - 50), genorator.Next(0, _graphics.PreferredBackBufferHeight - 50), 50, 50));





            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            backgroundTexture = Content.Load<Texture2D>("images/haunted-background");
            playerTexture = Content.Load<Texture2D>("images/mario");

            for (int i = 1; i <= 8; i++)
            {
                boosTextures.Add(Content.Load<Texture2D>( "images/boo-move-1"));
            }
            


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            mouseState = Mouse.GetState();  
            boos1.Update(mouseState);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            _spriteBatch.Draw(backgroundTexture, window, Color.White);
            boos1.Draw(_spriteBatch);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
