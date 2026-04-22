using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGameLibrary.Input;

public class InputManager
{
    //Gets the state information of keyboard info
    public KeyboardInfo Keyboard { get; private set; }
    //Gets the state information of the mouse info
    public MouseInfo Mouse { get; private set; }
    //Gets the state information of the gamepad info
    public GamePadInfo[] GamePads { get; private set; }

    //Creates a new input manager
    public InputManager()
    {
        Keyboard = new KeyboardInfo();
        Mouse = new MouseInfo();

        GamePads = new GamePadInfo[4];
        for (int i = 0; i < 4; i++)
        {
            GamePads[i] = new GamePadInfo((PlayerIndex)i);
        }
    }

    public void Update(GameTime gameTime)
    {
        Keyboard.Update();
        Mouse.Update();

        for (int i = 0; i < 4; i++)
        {
        GamePads[i].Update(gameTime);
        }
    }

}