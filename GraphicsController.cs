using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;

namespace ProjectOne;

public class GraphicsController {

    //keeping the texture list for now as a reminder about the array loading
    //private Texture2D[] tex2DList;
    private Texture2D tex2DFiveByFiveGrid;
    private Texture2D tex2DGreyBackground;

    public GraphicsController(ContentManager content) {
        /*
        tex2DList = new Texture2D[2];
        tex2DList[0] = content.Load<Texture2D>("Sprites/blue");
        tex2DList[1] = content.Load<Texture2D>("Sprites/red");
        */
        tex2DFiveByFiveGrid = content.Load<Texture2D>("Sprites/FiveByFiveGrid");
        tex2DGreyBackground = content.Load<Texture2D>("Sprites/greyBack");
    }

    public void Draw(SpriteBatch spriteBatch) {
        /*
        spriteBatch.Draw(tex2DList[0], new Rectangle(40, 40, 64, 64), Color.White);
        spriteBatch.Draw(tex2DList[1], new Rectangle(70, 70, 64, 64), Color.White);
        */
        //location seems kinda ugly; TODO figure out what to do about this
        spriteBatch.Draw(tex2DFiveByFiveGrid, new Rectangle(Game1.BoardDetails.xLocation, Game1.BoardDetails.yLocation, Game1.BoardDetails.sizePixels, Game1.BoardDetails.sizePixels), Color.White);
        spriteBatch.Draw(tex2DGreyBackground, new Rectangle(240, 360, 320, 120), Color.White);
    }
}