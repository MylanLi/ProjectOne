using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace ProjectOne;

public class BasicSprite : GraphicSprite {

    public BasicSprite(String tileColour) {
        //pass in the texture reference? or maybe just a string of the colour name, read it to use when generating?
        //details to hold, location?
        this.tileColour = tileColour;
    }

}