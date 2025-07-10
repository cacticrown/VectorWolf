using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace VectorWolf;

public static class Input
{
    private static KeyboardState _currentKeyboard;
    private static KeyboardState _lastKeyboard;

    private static MouseState _currentMouse;
    private static MouseState _lastMouse;

    public static void Update()
    {
        _lastKeyboard = _currentKeyboard;
        _currentKeyboard = Keyboard.GetState();

        _lastMouse = _currentMouse;
        _currentMouse = Mouse.GetState();
    }

    // Keyboard Methods
    public static bool KeyDown(Keys key) => _currentKeyboard.IsKeyDown(key);
    public static bool KeyUp(Keys key) => _currentKeyboard.IsKeyUp(key);
    public static bool KeyPressed(Keys key) => _currentKeyboard.IsKeyDown(key) && _lastKeyboard.IsKeyUp(key);
    public static bool KeyReleased(Keys key) => _currentKeyboard.IsKeyUp(key) && _lastKeyboard.IsKeyDown(key);

    // Mouse Methods
    public static Vector2 MousePosition => _currentMouse.Position.ToVector2();

    public static int MouseX => _currentMouse.X;
    public static int MouseY => _currentMouse.Y;

    public static bool LeftClick() =>
        _currentMouse.LeftButton == ButtonState.Pressed &&
        _lastMouse.LeftButton == ButtonState.Released;

    public static bool RightClick() =>
        _currentMouse.RightButton == ButtonState.Pressed &&
        _lastMouse.RightButton == ButtonState.Released;

    public static bool LeftDown() => _currentMouse.LeftButton == ButtonState.Pressed;
    public static bool RightDown() => _currentMouse.RightButton == ButtonState.Pressed;

    public static int ScrollWheelChange => _currentMouse.ScrollWheelValue - _lastMouse.ScrollWheelValue;
}
