using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//for write line
using System;

namespace ProjectOne;

public class Game1 : Game
{
    
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private GraphicsController graphicsController;
    //textures start here
    private Texture2D tex2DBlue;
    private Texture2D tex2DRed;
    private Texture2D tex2DFiveByFiveGrid;
    private Texture2D tex2DStars;
    //variables from learning, TODO: better way to do this
    private AnimatedSprite animatedSprite;
    private MouseState oldMouseState;
    private Vector2 starLocation = new Vector2(180,180);

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
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        animatedSprite.Update();

        
        MouseState newMouseState = Mouse.GetState();
        if(newMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released) {
            //starLocation = new Vector2(newMouseState.X, newMouseState.Y);
            //Console.WriteLine(starLocation);
        }
        oldMouseState = newMouseState;

        bool mouseOverSomething = false;

        if (Intersects(new Vector2(newMouseState.X, newMouseState.Y), graphicsController.blueBoundBox)) {
            Console.WriteLine("Blue");
        }

        

        if (!mouseOverSomething)
        {
            Console.WriteLine("Mouse Over:  None");
        }


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        

        _spriteBatch.Begin();
        
        _spriteBatch.Draw(tex2DFiveByFiveGrid, new Rectangle(0, 0, 320, 320), Color.White);
        graphicsController.Draw(_spriteBatch);
        
        _spriteBatch.End();
        animatedSprite.Draw(gameTime, _spriteBatch);
        
        //animatedSprite.Draw(gameTime, _spriteBatch, starLocation);

        base.Draw(gameTime);
    }

    //testing out raycast picking
    //public Ray CalculateRay(Vector2 mouseLocation, Matrix view, Matrix projection, Viewport viewport)
    public Ray CalculateRay(Vector2 mouseLocation)
    {
        Vector3 nearPoint = new Vector3(mouseLocation.X,mouseLocation.Y, 0.0f);
    
        Vector3 farPoint = new Vector3(mouseLocation.X,mouseLocation.Y, 1.0f);
    
                Vector3 direction = farPoint - nearPoint;
                direction.Normalize();
    
        return new Ray(nearPoint, direction);
    }



    public float? IntersectDistance(BoundingBox box, Vector2 mouseLocation)
    {
        Ray mouseRay = CalculateRay(mouseLocation);
        return mouseRay.Intersects(box);
    }



    public bool Intersects(Vector2 mouseLocation, BoundingBox box)
    {
        float? distance = IntersectDistance(box, mouseLocation);
    
        if (distance != null)
        {
            return true;
        }
                
    
        return false;
    }



}


