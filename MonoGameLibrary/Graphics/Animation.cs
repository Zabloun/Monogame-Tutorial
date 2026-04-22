using System;
using System.Collections.Generic;

namespace MonoGameLibrary.Graphics;

public class Animation
{
    //List of frames to be played in animation
    public List<TextureRegion> Frames { get; set; }
    //Delay before displaying each frame
    public TimeSpan Delay { get; set; }

    //Default Constructor => Creates Empty animation with default delay of 100ms
    public Animation()
    {
        Frames = new List<TextureRegion>();
        Delay = TimeSpan.FromMilliseconds(100);
    }

    //Constructor => Creates animation with frames and delay provided
    public Animation(List<TextureRegion> frames, TimeSpan delay)
    {
        Frames = frames;
        Delay = delay;
    }

}