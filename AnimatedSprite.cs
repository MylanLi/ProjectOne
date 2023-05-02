using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

public class AnimatedSprite {

    public Texture2D Texture { get; set; }
    public int Rows { get; set; }
    public int Columns { get; set; }
    private int currentFrame;
    private int totalFrames;
    private double animationTimer;
    private MouseState oldMouseState;
    private Vector2 starLocation = new Vector2(180,180);

    public AnimatedSprite(Texture2D texture, int rows, int columns) {
        Texture = texture;
        Rows = rows;
        Columns = columns;
        currentFrame = 0;
        totalFrames = Rows * Columns;
        animationTimer = 0;
    }

    public void Update() {
        MouseState newMouseState = Mouse.GetState();
        if(newMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released) {
            starLocation = new Vector2(newMouseState.X, newMouseState.Y);
        }
        oldMouseState = newMouseState;
    }

    

    //public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 location) {
    public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
        int width = Texture.Width / Columns;
        int height = Texture.Height / Rows;
        int row = currentFrame / Columns;
        int column = currentFrame % Columns;
    
        Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
        //Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);
        Rectangle destinationRectangle = new Rectangle((int)starLocation.X, (int)starLocation.Y, width, height);

        animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

        if(animationTimer > 2) {
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;
            animationTimer -= 2;
        }
    
        spriteBatch.Begin();
        spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        spriteBatch.End();
    }



}