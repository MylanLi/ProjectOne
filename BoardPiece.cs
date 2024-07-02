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
    public string myColour {get; set;}

    public BoardPiece(BasicSprite sprite, int locX, int locY) {
        pieceSprite = sprite;
        gridXLoc = locX;
        gridYLoc = locY;
        //TODO: get this string from a, forgot the name, but a reference file?
        myColour = "red";
    }
}