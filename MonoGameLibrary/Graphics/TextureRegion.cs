using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameLibrary.Graphics;

//Represents a rectangular region within a texture
public class TextureRegion
{
    //Gets or sets the source texture this texture region is part of.
    public Texture2D Texture { get; set; }

    //Gets or sets the source rectangle boundary of this texture region within the source texture.
    public Rectangle SourceRectangle { get; set; }

    //Gets the width in pixels of this texture region.
    public int Width => SourceRectangle.Width;

    //Gets the height in pixels of this texture region.
    public int Height => SourceRectangle.Height;

    //Default constructor => To create a texture in anticipation of use
    public TextureRegion()
    {
        
    }

    //Overloaded Constructor => Create a texture when the use is needed and all properties can be filled
    public TextureRegion(Texture2D texture, int x, int y, int width, int height)
    {
        Texture = texture;
        SourceRectangle = new Rectangle(x, y, width, height);
    }



    //Draw Methods

    //1. Simplest, takes only the 1. SpriteBatch 2. Position 3. Colour of texture region
    public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
    {
        Draw(spriteBatch, position, color, 0.0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0.0f);
    }
    //2. More Complex, allows access to all parameters, but forcing the scale to be 1:1
    public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
    {
        Draw(
            spriteBatch,
            position,
            color,
            rotation,
            origin,
            new Vector2(scale, scale),
            effects,
            layerDepth
        );
    }
    //3. Most Complex. allows all of 2. but allows independent x and y scalling => Allows for all the methods above to load
    //   Should've gone to the top
    public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
    {
        spriteBatch.Draw(
            Texture,
            position,
            SourceRectangle,
            color,
            rotation,
            origin,
            scale,
            effects,
            layerDepth
        );
    }
}