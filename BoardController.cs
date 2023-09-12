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

    //constructor, what to do though...
    public BoardController() {
        //i think this is probably necessary for the first click, but is it the best way? todo
        oldMouseState = Mouse.GetState();
        //for now just directly take it from main class hardcoded values
        boardRowAmount = Game1.BoardDetails.rowColAmount;
        boardColAmount = Game1.BoardDetails.rowColAmount;
    }

    //have this in the main update to "listen" for clicks
    public void Update(MouseState newMouseState) {

        if(newMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released) {
            CalculateSquare(newMouseState);
        }
        oldMouseState = newMouseState;
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