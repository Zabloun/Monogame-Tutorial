using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGameLibrary.Input;

public class MouseInfo
{
    #region Mouse Properties
    //State of mouse during previous input cycle
    public MouseState PreviousState { get; private set; }

    //State of mouse during current input cycle
    public MouseState CurrentState { get; private set; }

    //Gets or sets current position of the mouse cursor in screen space.
    public Point Position
    {
        get => CurrentState.Position;
        set => SetPosition(value.X, value.Y);
    }
    
    //Gets or sets the current x-coordinate position of the mouse cursor in screen space.
    public int X
    {
        get => CurrentState.X;
        set => SetPosition(value, CurrentState.Y);
    }

    //Gets or sets the current y-coordinate position of the mouse cursor in screen space.
    public int Y
    {
        get => CurrentState.Y;
        set => SetPosition(CurrentState.X, value);
    }

    //Gets the difference in the mouse cursor position between the previous and current frame.
    public Point PositionDelta => CurrentState.Position - PreviousState.Position;

    //Gets the difference in the mouse cursor x-position between the previous and current frame.
    public int XDelta => CurrentState.Position.X - PreviousState.Position.X;

    //Gets the difference in the mouse cursor y-position between the previous and current frame.
    public int YDelta => CurrentState.Position.Y - PreviousState.Position.Y;

    //Gets a value that indicates if the mouse cursor moved between previous and current frames.
    public bool WasMoved => PositionDelta != Point.Zero;

    //Gets the cumulative value of the mouse scroll wheel since the start of the game.
    public int ScrollWheel => CurrentState.ScrollWheelValue;

    //Gets the value of the scroll wheel between the previous and current frame.
    public int ScrollWheelDetla => CurrentState.ScrollWheelValue - PreviousState.ScrollWheelValue;

    #endregion


    //Constructor => Initializes object
    public MouseInfo()
    {
        PreviousState = new MouseState();
        CurrentState = Mouse.GetState();
    }
    
    /// <summary>
    /// Updates the state information about mouse input.
    /// </summary>
    public void Update()
    {
        PreviousState = CurrentState;
        CurrentState = Mouse.GetState();
    }

    /// <summary>
    /// Returns a value that indicates whether the specified mouse button is currently down.
    /// </summary>
    /// <param name="button">The mouse button to check.</param>
    /// <returns>true if the specified mouse button is currently down; otherwise, false.</returns>
    public bool IsButtonDown(MouseButton button)
    {
        switch (button)
        {
            case MouseButton.Left:
                return CurrentState.LeftButton == ButtonState.Pressed;
            case MouseButton.Middle:
                return CurrentState.MiddleButton == ButtonState.Pressed;
            case MouseButton.Right:
                return CurrentState.RightButton == ButtonState.Pressed;
            case MouseButton.XButton1:
                return CurrentState.XButton1 == ButtonState.Pressed;
            case MouseButton.XButton2:
                return CurrentState.XButton2 == ButtonState.Pressed;
            default:
                return false;
        }
    }

    /// <summary>
    /// Returns a value that indicates whether the specified mouse button is current up.
    /// </summary>
    /// <param name="button">The mouse button to check.</param>
    /// <returns>true if the specified mouse button is currently up; otherwise, false.</returns>
    public bool IsButtonUp(MouseButton button)
    {
        switch (button)
        {
            case MouseButton.Left:
                return CurrentState.LeftButton == ButtonState.Released;
            case MouseButton.Middle:
                return CurrentState.MiddleButton == ButtonState.Released;
            case MouseButton.Right:
                return CurrentState.RightButton == ButtonState.Released;
            case MouseButton.XButton1:
                return CurrentState.XButton1 == ButtonState.Released;
            case MouseButton.XButton2:
                return CurrentState.XButton2 == ButtonState.Released;
            default:
                return false;
        }
    }

    /// <summary>
    /// Returns a value that indicates whether the specified mouse button was just pressed on the current frame.
    /// </summary>
    /// <param name="button">The mouse button to check.</param>
    /// <returns>true if the specified mouse button was just pressed on the current frame; otherwise, false.</returns>
    public bool WasButtonJustPressed(MouseButton button)
    {
        switch (button)
        {
            case MouseButton.Left:
                return CurrentState.LeftButton == ButtonState.Pressed && PreviousState.LeftButton == ButtonState.Released;
            case MouseButton.Middle:
                return CurrentState.MiddleButton == ButtonState.Pressed && PreviousState.MiddleButton == ButtonState.Released;
            case MouseButton.Right:
                return CurrentState.RightButton == ButtonState.Pressed && PreviousState.RightButton == ButtonState.Released;
            case MouseButton.XButton1:
                return CurrentState.XButton1 == ButtonState.Pressed && PreviousState.XButton1 == ButtonState.Released;
            case MouseButton.XButton2:
                return CurrentState.XButton2 == ButtonState.Pressed && PreviousState.XButton2 == ButtonState.Released;
            default:
                return false;
        }
    }

    /// <summary>
    /// Returns a value that indicates whether the specified mouse button was just released on the current frame.
    /// </summary>
    /// <param name="button">The mouse button to check.</param>
    /// <returns>true if the specified mouse button was just released on the current frame; otherwise, false.</returns>
    public bool WasButtonJustReleased(MouseButton button)
    {
        switch (button)
        {
            case MouseButton.Left:
                return CurrentState.LeftButton == ButtonState.Released && PreviousState.LeftButton == ButtonState.Pressed;
            case MouseButton.Middle:
                return CurrentState.MiddleButton == ButtonState.Released && PreviousState.MiddleButton == ButtonState.Pressed;
            case MouseButton.Right:
                return CurrentState.RightButton == ButtonState.Released && PreviousState.RightButton == ButtonState.Pressed;
            case MouseButton.XButton1:
                return CurrentState.XButton1 == ButtonState.Released && PreviousState.XButton1 == ButtonState.Pressed;
            case MouseButton.XButton2:
                return CurrentState.XButton2 == ButtonState.Released && PreviousState.XButton2 == ButtonState.Pressed;
            default:
                return false;
        }
    }

    /// <summary>
    /// Sets the current position of the mouse cursor in screen space and updates the CurrentState with the new position.
    /// </summary>
    /// <param name="x">The x-coordinate location of the mouse cursor in screen space.</param>
    /// <param name="y">The y-coordinate location of the mouse cursor in screen space.</param>
    public void SetPosition(int x, int y)
    {
        Mouse.SetPosition(x, y);
        CurrentState = new MouseState(
            x,
            y,
            CurrentState.ScrollWheelValue,
            CurrentState.LeftButton,
            CurrentState.MiddleButton,
            CurrentState.RightButton,
            CurrentState.XButton1,
            CurrentState.XButton2
        );
    }



}