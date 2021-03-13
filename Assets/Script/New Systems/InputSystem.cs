using UnityEngine;
using UnityEngine.Events;

public class InputSystem : IGameSystemMono, IInputBehavior, IQuickDoubleTap
{
    private float beginTime;
    private float quickTapTime = 0.3f;
    private float quickTapPressTime = 0.3f;
    private bool doubleTap = false;

    public UnityEvent InputBeginEvent = new UnityEvent();
    public UnityEvent InputPressEvent = new UnityEvent();
    public UnityEvent InputEndEvent = new UnityEvent();
    public UnityEvent QuickDoubleTapEvent = new UnityEvent();
    public UnityEvent QuickDoubleTapPressEvent = new UnityEvent();

    public override void StartGameSystem() { }
    public override void DestoryGameSystem() { }

    public bool InputBegin() { return Input.GetMouseButtonDown(0); }
    public bool InputPress() { return Input.GetMouseButton(0); }
    public bool InputEnd() { return Input.GetMouseButtonUp(0); }
    public bool QuickDoubleTap()
    {
        if (Time.time - beginTime < quickTapTime)
        {
            doubleTap = true;
            return true;
        }
        return false;
    }
    public bool QuickDoubleTapPress()
    {
        if (doubleTap)
        {
            if (Time.time - beginTime > quickTapPressTime)
            {
                return true;
            }
        }
        return false;
    }

    private void Update()
    {
        if (InputBegin())
        {
            InputBeginEvent.Invoke();

            if (QuickDoubleTap())
            {
                QuickDoubleTapEvent.Invoke();
            }
            beginTime = Time.time;
        }            
        else if (InputPress())
        {
            InputPressEvent.Invoke();

            if (QuickDoubleTapPress())
            {
                QuickDoubleTapPressEvent.Invoke();
            }
        }            
        else if (InputEnd())
        {
            InputEndEvent.Invoke();

            if (doubleTap)
                doubleTap = false;
        }
    }
}
public interface IInputBehavior
{
    bool InputBegin();
    bool InputPress();
    bool InputEnd();
}
public interface IQuickDoubleTap
{
    bool QuickDoubleTap();
    bool QuickDoubleTapPress();
}
