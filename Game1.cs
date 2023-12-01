//Learning project about monogame
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
    
    //TODO: repurpose GraphicsController, as per below
    private GraphicsController graphicsController;
    //textures start here
    //todo, looked into csharp values stuff, should be able to load texttures just once
    //so figure out where to load textures, probably not here
    //also, grapchicsController might be unecessary, better to have the different sections draw their sprites
    //maybe rename it backgroundUIController

    //TODO: decide whether to move the grid somewhere else?
    private Texture2D tex2DFiveByFiveGrid;

    //attempts at playarea
    //attempts at drawing spritefonts
    private SpriteFont font;

    private Texture2D tex2DGreyBack;
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
        graphicsController = new GraphicsController(Content);
        boardController = new BoardController(Content);
        base.Initialize();
    }

    //todo: see comment at the top about not loading here, though itll be calling LoadContent methods from ehre
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here

        tex2DFiveByFiveGrid = Content.Load<Texture2D>("Sprites/FiveByFiveGrid");
    
        //attempts at playarea
        //attempts at spritefont
        font = Content.Load<SpriteFont>("BasicText");
        tex2DGreyBack = Content.Load<Texture2D>("Sprites/greyBack");
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
        _spriteBatch.Draw(tex2DFiveByFiveGrid, new Rectangle(BoardDetails.xLocation, BoardDetails.yLocation, BoardDetails.sizePixels, BoardDetails.sizePixels), Color.White);
        _spriteBatch.Draw(tex2DGreyBack, new Rectangle(240, 360, 320, 120), Color.White);
        graphicsController.Draw(_spriteBatch);
        _spriteBatch.DrawString(font, displayText, new Vector2(250, 370), Color.Black);
        
        boardController.Draw(gameTime, _spriteBatch);

        _spriteBatch.End();
        
        base.Draw(gameTime);
    }
}
