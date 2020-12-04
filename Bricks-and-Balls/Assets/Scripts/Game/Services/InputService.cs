
using UnityEngine;

public class InputService
{
    private static Camera _camera;
    public static Camera Camera => _camera;
    public static Vector2 clickPosition;
    
    static InputService() => _camera = Camera.main;

#if UNITY_EDITOR

    public static bool isScreenDownClick()
    {
        clickPosition = Camera.ScreenToWorldPoint(Input.mousePosition);
        return Input.GetMouseButtonDown(0);
    }
    
    public static bool isScreenHoldingClick()
    {
        clickPosition = Camera.ScreenToWorldPoint(Input.mousePosition);
        return Input.GetMouseButton(0);
    }
    
    public static bool isScreenUpClick()
    {
        clickPosition = Camera.ScreenToWorldPoint(Input.mousePosition);
        return Input.GetMouseButtonUp(0);
    }
#elif UNITY_ANDROID
    public static bool isScreenDownClick()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            clickPosition = touch.position;    
            return touch.phase == TouchPhase.Began;
        }
    }

    public static bool isScreenHoldingClick()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            clickPosition = touch.position;
            return touch.phase == TouchPhase.Ended;
        }
    }

    public static bool isScreenUpClick()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            clickPosition = touch.position;
            return touch.phase == TouchPhase.Ended;
        }
    }
#endif
}
