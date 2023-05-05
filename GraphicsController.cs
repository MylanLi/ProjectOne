using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;

namespace ProjectOne;

public class GraphicsController {
    //private SpriteBatch spriteBatch;
    private Texture2D[] tex2DList;

    public GraphicsController(ContentManager content) {
        tex2DList = new Texture2D[2];
        tex2DList[0] = content.Load<Texture2D>("Sprites/blue");
        tex2DList[1] = content.Load<Texture2D>("Sprites/red");
    }

    public void Draw(SpriteBatch spriteBatch) {
        //spriteBatch.Begin();

        spriteBatch.Draw(tex2DList[0], new Rectangle(40, 40, 64, 64), Color.White);
        spriteBatch.Draw(tex2DList[1], new Rectangle(70, 70, 64, 64), Color.White);

        //spriteBatch.End();
    }
}