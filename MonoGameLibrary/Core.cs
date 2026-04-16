using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameLibrary;

public class Core : Game
{
    internal static Core s_instance; 

    public static Core Instance => s_instance; //Reference to the Core instance

    public static GraphicsDeviceManager Graphics { get; private set; } //Gets graphics design manager

    public static new GraphicsDevice GraphicsDevice { get; private set; } //Get graphics device used to create graphical resources and rendering

    public static SpriteBatch SpriteBatch { get; private set; } //Gets the spritebatch for all 2D renders

    public static new ContentManager Content { get; private set; } //Gets the content manager used to load global assets

    /// <summary>
    /// Creates a new Core instance.
    /// </summary>
    /// <param name="title">The title to display in the title bar of the game window.</param>
    /// <param name="width">The initial width, in pixels, of the game window.</param>
    /// <param name="height">The initial height, in pixels, of the game window.</param>
    /// <param name="fullScreen">Indicates if the game should start in fullscreen mode.</param>
    public Core(string title, int width, int height, bool fullScreen)
    {
        //Ensures only one instance of core can exist at a time
        if (s_instance != null)
        {
            throw new InvalidOperationException($"Only a single Core instance can be created"); //Essential a Signleton
        }

        //Setting global instance to this instance of core
        s_instance = this;

        //Creating a new graphics managers
        Graphics = new GraphicsDeviceManager(this);

        //Setting the graphics defaults
        Graphics.PreferredBackBufferWidth = width;
        Graphics.PreferredBackBufferHeight = height;
        Graphics.IsFullScreen = fullScreen;

        //Applying changes
        Graphics.ApplyChanges();

        //Set the window title
        Window.Title = title;

        //Setting the core contents manager to a reference of the base Game's content manager
        Content = base.Content;

        //Set the root directory for content
        Content.RootDirectory = "Content";

        //Mouse is visible by default
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();

        //Set the core's graphics device to a reference of the base Game's
        GraphicsDevice = base.GraphicsDevice;

        //Creating spritebatch instance
        SpriteBatch = new SpriteBatch(GraphicsDevice);
    }


}