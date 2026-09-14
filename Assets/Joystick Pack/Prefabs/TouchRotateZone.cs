using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;

public class TouchRotateZone : OnScreenControl, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [InputControl(layout = "Vector2")]
    [SerializeField] private string _controlPath;

    protected override string controlPathInternal { get => _controlPath; set => _controlPath = value; }

    public void OnDrag(PointerEventData eventData)
    {
        // 核心：直接发送手指的滑动增量 (Delta)
        SendValueToControl(eventData.delta);
    }

    public void OnPointerDown(PointerEventData eventData) { }

    public void OnPointerUp(PointerEventData eventData)
    {
        // 手指抬起时，将增量归零，防止视角停不下来
        SendValueToControl(Vector2.zero);
    }
}