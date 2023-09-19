using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ProjectOne;

public abstract class GraphicSprite {
    public string tileColour;
    public string getTileColour() {
        return tileColour;
    }
}