//Controller for managing clicks on the board
//i.e. clicks on the screen would be handled by logic here
//Should just be one instance
//Idea: Abstract class for clickable screen space?

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace ProjectOne;

public class BoardController {

    private MouseState oldMouseState;
    //constants about the board
    private int boardRowAmount;
    private int boardColAmount;

    //hard code it for testing i guess
    private GraphicSprite[] spriteList = new GraphicSprite[6];
    //todo, remove code that uses the GraphicSprite array, outdated now that BoardPiece class exists
    private BoardPiece[,] boardPieceList;

    private Texture2D blueTexture;
    private Texture2D redTexture;
    private Texture2D starTexture;
    private Texture2D yellowOutline;

    //boardpiece testing
    private BoardPiece testPiece;

    //for board logic
    private Boolean currentlySelected = false;
    private int selectedX;
    private int selectedY;

    //constructor
    public BoardController(ContentManager content) {
        //i think this is probably necessary for the first click, but is it the best way? todo
        oldMouseState = Mouse.GetState();
        //for now just directly take it from main class hardcoded values, shift to the static one later?
        boardRowAmount = Game1.BoardDetails.rowColAmount;
        boardColAmount = Game1.BoardDetails.rowColAmount;

        //TOTHINK: do i have the textures all over the place? seems bad
        blueTexture = content.Load<Texture2D>("Sprites/blue");
        redTexture = content.Load<Texture2D>("Sprites/red");
        starTexture = content.Load<Texture2D>("Sprites/stars");
        yellowOutline = content.Load<Texture2D>("Sprites/yellowOutline");

        spriteList[4] = new AnimatedSprite(starTexture,1,3, new Vector2(180,180));

        //hardcode a BoardPiece for testing
        testPiece = new BoardPiece(new BasicSprite("Blue", blueTexture),200,120);

        boardPieceList = new BoardPiece[boardRowAmount,boardColAmount];
        //try and test out controllling the board and moving pieces around
        CreateBoardPiece(1, 2, "Red",boardPieceList);
        CreateBoardPiece(4, 3, "Red",boardPieceList);

    }

    //have this in the main update to "listen" for clicks
    public void Update(MouseState newMouseState) {
        int xSquare;
        int ySquare;

        //for testing moving a square
        BoardPiece tempPiece;

        if(newMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released) {
            (xSquare, ySquare) = CalculateSquare(newMouseState);
            Game1.displayText = xSquare.ToString() + " , " + ySquare.ToString();
            //TODO: not on board when its 0,0
            if(xSquare != 0) {
                if(currentlySelected) {
                    //testing moving a square
                    if((boardPieceList[selectedX -1,selectedY -1] != null) && (boardPieceList[xSquare -1, ySquare -1] == null)) {
                        tempPiece = boardPieceList[selectedX -1,selectedY -1];

                        (tempPiece.gridXLoc, tempPiece.gridYLoc) = SquareToLocation(xSquare, ySquare);

                        boardPieceList[xSquare -1, ySquare -1] = tempPiece;
                        boardPieceList[selectedX -1,selectedY -1] = null;
                    }
                    //----
                    currentlySelected = false;
                } else {
                    currentlySelected = true;
                    selectedX = xSquare;
                    selectedY = ySquare;
                }
            }
        }
        oldMouseState = newMouseState;
        //downcasting, apparently bad?
        ((AnimatedSprite)spriteList[4]).Update();
        //the second one shouldnt follow click then
        //((AnimatedSprite)spriteList[5]).Update();

        

    }

    //todo, change the location lol
    public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {

        //testing going through array and drawing the pieces
        for(int i = 0; i < boardRowAmount; i++) {
            for(int j = 0; j < boardColAmount; j++) {
                if(boardPieceList[i,j] == null) {
                    continue;
                } else {
                    DrawHelper(spriteBatch, boardPieceList[i,j]);
                }
            }
        }
        
        //hardcoding this while the loop is being worked on
        ((AnimatedSprite)spriteList[4]).Draw(gameTime, spriteBatch);

        DrawHelper(spriteBatch, testPiece);
        if(currentlySelected) {
            var (newXLoc, newYLoc) = SquareToLocation(selectedX,selectedY);
            spriteBatch.Draw(yellowOutline, new Rectangle(newXLoc,newYLoc,64,64), Color.White);
            //TODO: fix size of outline, put it on the square
        }
    }

    //figure out which square was clicked
    private (int, int) CalculateSquare(MouseState someMouseState) {

        //todo, check the edges of sprites
        //todo fix the 320 magic number (size of board)
        if (someMouseState.X >= 240 && someMouseState.X <= (240 + 320)) {
            if (someMouseState.Y >= 20 && someMouseState.Y <= (20+320)) {
                int xSquare = ((someMouseState.X - 240)/(320/boardRowAmount)) + 1;
                int ySquare = ((someMouseState.Y - 20)/(320/boardColAmount)) + 1;
                //Game1.displayText = xSquare.ToString() + " , " + ySquare.ToString();
                return(xSquare, ySquare);
            }
        }

        //TODO: fix issue where clicking on the grey background doesnt change from a grid number to not on board
        //Game1.displayText = "not on board";
        return (0,0);      
    }

    private (int, int) SquareToLocation(int xSquare, int ySquare) {
        int newXLoc = 0;
        int newYLoc = 0;

        //todo: fix magic numbers
        if ( xSquare > 0 && xSquare <= boardRowAmount && ySquare > 0 && ySquare <= boardColAmount ) {
            newXLoc = 240 + (xSquare - 1)*64;
            newYLoc = 20 + (ySquare - 1)*64;
        }

        //todo: unexpected error handling
        return(newXLoc,newYLoc);
    }

    //for drawing pieces using their own stored vars
    private void DrawHelper(SpriteBatch spriteBatch, BoardPiece drawnPiece) {
        Texture2D drawColour;

        //TODO: expand this
        if (drawnPiece.myColour == "Red") {
            drawColour = redTexture;
        } else {
            drawColour = blueTexture;
        }

        //TODO: the 64 by 64 size to be referenced from somewhere
        spriteBatch.Draw(drawColour, new Rectangle(drawnPiece.gridXLoc, drawnPiece.gridYLoc, 64, 64), Color.White);
    }

    private void CreateBoardPiece(int xSpot, int ySpot, String pieceColour, BoardPiece[,] boardPieceList) {
        var (xLoc, yLoc) = SquareToLocation(xSpot, ySpot);

        Texture2D pieceTexture;

        if (pieceColour == "Red") {
            pieceTexture = redTexture;
        } else {
            pieceTexture = blueTexture;
        }

        boardPieceList[xSpot - 1, ySpot - 1] = new BoardPiece(new BasicSprite(pieceColour, pieceTexture), xLoc, yLoc);
    }
}