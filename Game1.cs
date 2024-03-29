﻿//Learning project about monogame
//Aim is to make a 2D game
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectOne;

public class Game1 : Game
{
    //these two seem to be inbuilts
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    
    private BackgroundUIController backgroundUIController;

    //attempts at playarea
    //attempts at drawing spritefonts
    private SpriteFont font;
    private BoardController boardController;

    //temp string to display
    //TODO: currently coupled to boardcontroller, change
    public static String displayText = "some text";

    //temp hardcoded values for "level details"
    public static class BoardDetails {
        public const int rowColAmount = 5;
        public const int sizePixels = 320;
        public const int xLocation = 240;
        public const int yLocation = 20;
    }

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        backgroundUIController = new BackgroundUIController(Content);
        boardController = new BoardController(Content);
        base.Initialize();
    }

    //todo: see comment at the top about not loading here, though itll be calling LoadContent methods from ehre
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        //attempts at spritefont
        font = Content.Load<SpriteFont>("BasicText");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        //pass this instead of having all the updates get it themselves
        //try it with board controller for now
        MouseState newMouseState = Mouse.GetState();
        // TODO: Add your update logic here

        boardController.Update(newMouseState);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        
        //windown default size 800 x 480
        backgroundUIController.Draw(_spriteBatch);
        _spriteBatch.DrawString(font, displayText, new Vector2(250, 370), Color.Black);
        
        boardController.Draw(gameTime, _spriteBatch);

        _spriteBatch.End();
        
        base.Draw(gameTime);
    }
}
