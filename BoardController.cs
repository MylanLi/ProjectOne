//Controller for managing clicks on the board
//i.e. clicks on the screen would be handled by logic here
//Should just be one instance
//Idea: Abstract class for clickable screen space?

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
    private GraphicSprite[] spriteList = new GraphicSprite[6];
    private Texture2D blueTexture;
    private Texture2D redTexture;
    private Texture2D starTexture;

    //boardpiece testing
    private BoardPiece testPiece;

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

        /*
        //tseting w hardcode
        spriteList[0] = new BasicSprite("Blue");
        spriteList[1] = new BasicSprite("Red");
        spriteList[2] = new BasicSprite("Red");
        spriteList[3] = new BasicSprite("Blue");
        
        spriteList[5] = new AnimatedSprite(starTexture,1,3, new Vector2(280,280));
        */

        spriteList[4] = new AnimatedSprite(starTexture,1,3, new Vector2(180,180));

        //hardcode a BoardPiece for testing
        testPiece = new BoardPiece(new BasicSprite("Blue", blueTexture),200,350);
    }

    //have this in the main update to "listen" for clicks
    public void Update(MouseState newMouseState) {

        if(newMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released) {
            CalculateSquare(newMouseState);
        }
        oldMouseState = newMouseState;
        //downcasting, apparently bad?
        ((AnimatedSprite)spriteList[4]).Update();
        //the second one shouldnt follow click then
        //((AnimatedSprite)spriteList[5]).Update();

    }

    //todo, change the location lol
    public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
        /*
        //looping through the sprite list
        for (int i = 0; i < spriteList.Length; i++) {
            switch (spriteList[i].getTileColour()) {
                case "Blue":
                    spriteBatch.Draw(blueTexture, new Rectangle(240, 167, 64, 64), Color.White);
                    break;
                case "Red":
                    spriteBatch.Draw(redTexture, new Rectangle(138, 90, 64, 64), Color.White);
                    break;
                case "Star":
                    ((AnimatedSprite)spriteList[i]).Draw(gameTime, spriteBatch);
                    break;
            }
        }
        */
        
        //hardcoding this while the loop is being worked on
        ((AnimatedSprite)spriteList[4]).Draw(gameTime, spriteBatch);
        testPiece.Draw(spriteBatch);
    }

    //figure out which square was clicked
    private void CalculateSquare(MouseState someMouseState) {

        //todo, check the edges of sprites
        if (someMouseState.X >= 240 && someMouseState.X <= (240 + 320)) {
            if (someMouseState.Y >= 20 && someMouseState.Y <= (20+320)) {
                int xSquare = ((someMouseState.X - 240)/(320/boardRowAmount)) + 1;
                int ySquare = ((someMouseState.Y - 20)/(320/boardColAmount)) + 1;
                Game1.displayText = xSquare.ToString() + " , " + ySquare.ToString();
            }
        } else {
            //TODO: fix issue where clicking on the grey background doesnt change from a grid number to not on board
            Game1.displayText = "not on board";
        }
    }
}