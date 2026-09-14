using UnityEngine;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;

public class JoystickInputBridge : OnScreenControl
{
    // 1. 拖入你的 Joystick (比如 FloatingJoystick 或 FixedJoystick)
    [Header("Settings")]
    public Joystick joystick;

    // 2. 选择路径 (比如 Gamepad/LeftStick)
    [InputControl(layout = "Vector2")]
    [SerializeField]
    private string _controlPath;

    protected override string controlPathInternal
    {
        get => _controlPath;
        set => _controlPath = value;
    }

    private void Update()
    {
        if (joystick == null) return;

        // 获取摇杆坐标并发送给 Input System
        Vector2 input = new Vector2(joystick.Horizontal, joystick.Vertical);
        SendValueToControl(input);
    }
}