using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;

namespace ProjectOne;

public class GraphicsController {
    //private SpriteBatch spriteBatch;
    private Texture2D[] tex2DList;

    public BoundingBox blueBoundBox;
    public BoundingBox redBoundBox;

    public GraphicsController(ContentManager content) {
        tex2DList = new Texture2D[2];
        tex2DList[0] = content.Load<Texture2D>("Sprites/blue");
        tex2DList[1] = content.Load<Texture2D>("Sprites/red");

        blueBoundBox = new BoundingBox(new Vector3(40,40,0), new Vector3(104,104,1));
        redBoundBox = new BoundingBox(new Vector3(120,120,0), new Vector3(184, 184, 1));
    }

    public void Draw(SpriteBatch spriteBatch) {
        //spriteBatch.Begin();

        spriteBatch.Draw(tex2DList[0], new Rectangle(40, 40, 64, 64), Color.White);
        spriteBatch.Draw(tex2DList[1], new Rectangle(120, 120, 64, 64), Color.White);

        //spriteBatch.End();
    }
}