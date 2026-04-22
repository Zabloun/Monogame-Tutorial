using System.Diagnostics.Contracts;
using Microsoft.Xna.Framework.Input;

namespace MonoGameLibrary.Input;

public class KeyboardInfo
{
    //Gets the state of keyboard input during previous update cycle.
    public KeyboardState PreviousState { get; private set; }
    //Gets the state of keyboard input during current input cycle.
    public KeyboardState CurrentState { get; private set; }

    //Constructor => Initialises keyboardinfo
    public KeyboardInfo()
    {
        PreviousState = new KeyboardState();
        CurrentState = Keyboard.GetState();
    }

    //Updates the state information about keyboard info
    public void Update()
    {
        PreviousState = CurrentState;
        CurrentState = Keyboard.GetState();
    }

    #region Key methods
    
    //Returns a value that indicates if the specified key is currently down
    public bool IsKeyDown(Keys key)
    {
        return CurrentState.IsKeyDown(key);
    }

    //Returns a value that indicates if the specified key is currently up
    public bool IsKeyUp(Keys key)
    {
        return CurrentState.IsKeyUp(key);
    }

    //Returns a value that indicates if the specified key was just pressed on the current frame
    public bool WasKeyJustPressed(Keys key)
    {
        return CurrentState.IsKeyDown(key) && PreviousState.IsKeyUp(key);
    }

    //Returns a value that indicates if the specified key was just released on the current frame
    public bool WasKeyJustReleased(Keys key)
    {
        return CurrentState.IsKeyUp(key) && CurrentState.IsKeyDown(key);
    }


    #endregion


}