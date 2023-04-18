using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectOne;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D tex2DBlue;
    private Texture2D tex2DRed;
    private Texture2D tex2DFiveByFiveGrid;
    private Texture2D tex2DStars;
    private AnimatedSprite animatedSprite;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        tex2DBlue = Content.Load<Texture2D>("Sprites/blue");
        tex2DRed = Content.Load<Texture2D>("Sprites/red");
        tex2DFiveByFiveGrid = Content.Load<Texture2D>("Sprites/FiveByFiveGrid");
        tex2DStars = Content.Load<Texture2D>("Sprites/stars");
        animatedSprite = new AnimatedSprite(tex2DStars,1,3);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        animatedSprite.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        

        _spriteBatch.Begin();
        
        _spriteBatch.Draw(tex2DFiveByFiveGrid, new Rectangle(0, 0, 320, 320), Color.White);
        
        _spriteBatch.End();

        animatedSprite.Draw(_spriteBatch, new Vector2(400, 200));

        base.Draw(gameTime);
    }
}
