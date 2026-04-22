using System;
using Microsoft.Xna.Framework;

namespace MonoGameLibrary.Graphics;

public class AnimatedSprite : Sprite
{
    private int _currentFrame;
    private TimeSpan _elapsed;
    private Animation _animation;

    //Gets or sets the animation for this animated sprite
    public Animation Animation
    {
        get => _animation;
        set
        {
            _animation = value;
            Region = _animation.Frames[0];
        }
    }

    //Default Constructor => initializes the AnimatedSprite object in an empty state
    public AnimatedSprite()
    {

    }

    //Creates a new animated sprite with the specified frames and delay
    //animation => The animation for this animated sprite
    public AnimatedSprite(Animation animation)
    {
        Animation = animation;
    }


    //Updates this aniamted sprite.
    //gameTime => A snapshot of the game timing values provided by the framework
    public void Update(GameTime gameTime)
    {
        _elapsed += gameTime.ElapsedGameTime;
        if (_elapsed >= _animation.Delay)
        {
            _elapsed -= _animation.Delay;
            _currentFrame++;

            if (_currentFrame >= _animation.Frames.Count)
            {
                _currentFrame = 0;
            }

            Region = _animation.Frames[_currentFrame];
        }
    }

}