//Controller for managing clicks on the board
//Clicks on the board 

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ProjectOne;

public class BoardController {

    private MouseState oldMouseState;
    //constants about the board
    private int boardRowAmount;
    private int boardColAmount;
    //hard code it for testing i guess
    private BasicSprite[] spriteList = new BasicSprite[4];
    private Texture2D blueTexture;
    private Texture2D redTexture;

    //constructor, what to do though...
    public BoardController(ContentManager content) {
        //i think this is probably necessary for the first click, but is it the best way? todo
        oldMouseState = Mouse.GetState();
        //for now just directly take it from main class hardcoded values
        boardRowAmount = Game1.BoardDetails.rowColAmount;
        boardColAmount = Game1.BoardDetails.rowColAmount;


        //tseting w hardcode
        spriteList[0] = new BasicSprite("Blue");
        spriteList[1] = new BasicSprite("Red");
        spriteList[2] = new BasicSprite("Red");
        spriteList[3] = new BasicSprite("Blue");

        blueTexture = content.Load<Texture2D>("Sprites/blue");
        redTexture = content.Load<Texture2D>("Sprites/red");
    }

    //have this in the main update to "listen" for clicks
    public void Update(MouseState newMouseState) {

        if(newMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released) {
            CalculateSquare(newMouseState);
        }
        oldMouseState = newMouseState;
    }

    //todo, change the location lol
    public void Draw(SpriteBatch spriteBatch) {
        for (int i = 0; i < spriteList.Length; i++) {
            switch (spriteList[i].getTileColour()) {
                case "Blue":
                    spriteBatch.Draw(blueTexture, new Rectangle(240, 167, 64, 64), Color.White);
                    break;
                case "Red":
                    spriteBatch.Draw(redTexture, new Rectangle(138, 90, 64, 64), Color.White);
                    break;
            }
        }
    }

    //figure out which square was clicked
    private void CalculateSquare(MouseState someMouseState) {

        //todo, check the edges of sprites
        if (someMouseState.X >= 240 && someMouseState.X <= (240 + 320)) {
            if (someMouseState.Y >= 20 && someMouseState.Y <= (20+320)) {
                int xSquare = ((someMouseState.X - 240)/(320/5)) + 1;
                int ySquare = ((someMouseState.Y - 20)/(320/5)) + 1;
                Game1.displayText = xSquare.ToString() + " , " + ySquare.ToString();
            }
        } else {
            Game1.displayText = "not on board";
        }
    }
}