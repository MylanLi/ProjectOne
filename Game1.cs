using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectOne;

public class Game1 : Game
{
    
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private GraphicsController graphicsController;
    //textures start here
    private Texture2D tex2DFiveByFiveGrid;
    private Texture2D tex2DStars;
    //variables from learning, TODO: better way to do this
    private AnimatedSprite animatedSprite;
    private Vector2 starLocation = new Vector2(180,180);

    //attempts at playarea
    //attempts at drawing spritefonts
    private SpriteFont font;
    private int score = 0;
    private Texture2D tex2DGreyBack;
    private BoardController boardController;

    //temp string to display
    public static String displayText = "some text";

    //hardcoded values for "level details"
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
        boardController = new BoardController();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here

        //tex2DBlue = Content.Load<Texture2D>("Sprites/blue");
        //tex2DRed = Content.Load<Texture2D>("Sprites/red");
        tex2DFiveByFiveGrid = Content.Load<Texture2D>("Sprites/FiveByFiveGrid");
        tex2DStars = Content.Load<Texture2D>("Sprites/stars");
        animatedSprite = new AnimatedSprite(tex2DStars,1,3);
    
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
        animatedSprite.Update();
        boardController.Update(newMouseState);
        /*
        MouseState newMouseState = Mouse.GetState();
        if(newMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released) {
            starLocation = new Vector2(newMouseState.X, newMouseState.Y);
        }
        oldMouseState = newMouseState;
        */


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
        
        _spriteBatch.End();
        animatedSprite.Draw(gameTime, _spriteBatch);
        
        //animatedSprite.Draw(gameTime, _spriteBatch, starLocation);

        base.Draw(gameTime);
    }
}
