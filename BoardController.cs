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
        oldMouseState = Mouse.GetState();
        //for now just hard code it
        boardRowAmount = Game1.BoardDetails.rowColAmount;
        boardColAmount = Game1.BoardDetails.rowColAmount;
    }

    //have this in the main update to "listen" for clicks
    public void Update() {
        MouseState newMouseState = Mouse.GetState();
        if(newMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released) {
            Console.WriteLine(boardColAmount);
        }
        oldMouseState = newMouseState;
    }
}