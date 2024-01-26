//Represents pieces on the board, for game logic
//TODO: investigate what other game logic is needed for this to be abstracted
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ProjectOne;

public class BoardPiece {

    //sprite associated with this piece
    //TOTHINK: switching sprites later on when game logic happens
    private BasicSprite pieceSprite;

    //for the board location of the piece
    //TODO: consider vector2s again
    public int gridXLoc {get; set;}
    public int gridYLoc {get; set;}

    public BoardPiece(BasicSprite sprite, int locX, int locY) {
        pieceSprite = sprite;
        gridXLoc = locX;
        gridYLoc = locY;
    }

    public void Draw(SpriteBatch spriteBatch) {
        spriteBatch.Draw(pieceSprite.Texture,new Rectangle(gridXLoc,gridYLoc,40,40), Color.White);
    }
}