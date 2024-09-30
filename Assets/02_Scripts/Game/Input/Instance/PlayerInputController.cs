using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum MouseInputType
{
    Down,
    Up
}

public class PlayerInputController : MonoBehaviour, IInputController, InputMap.IPlayerActions
{

    private Dictionary<int, IEventContainer<int>.Event> _eventContainer = new();
    private Dictionary<int, object> _valueContainer = new();
    private InputMap _input;

    #region Hash
    private readonly int HASH_MOUSE_POSITION = "MousePosition".GetHash();
    private readonly int HASH_L_MOUSE_BUTTON = "LeftButton".GetHash();
    private readonly int HASH_R_MOUSE_BUTTON = "RightButton".GetHash();
    #endregion

    private void Awake()
    {
        
        _input = new InputMap();
        _input.Player.Enable();
        _input.Player.SetCallbacks(this);

    }

    public void NotifyEvent(int key, params object[] value)
    {
        if (_eventContainer.TryGetValue(key, out var v))
            v?.Invoke(value);
    }

    public void RegisterEvent(int key, IEventContainer<int>.Event evt)
    {

        if (!_eventContainer.ContainsKey(key))
            _eventContainer.Add(key, null);

        _eventContainer[key] += evt;

    }


    public void UnregisterEvent(int key, IEventContainer<int>.Event evt)
    {

        if (!_eventContainer.ContainsKey(key))
            return;

        _eventContainer[key] -= evt;

    }

    public T GetValue<T>(int key)
    {

        if (_valueContainer.TryGetValue(key, out var v))
            return v.Cast<T>();

        return default;

    }

    public void SetValue<T>(int key, T value)
    {

        _valueContainer[key] = value;

    }


    public void OnMouse(InputAction.CallbackContext context)
    {

        SetValue(HASH_MOUSE_POSITION, context.ReadValue<Vector2>());

    }

    public void OnMouseLeftButton(InputAction.CallbackContext context)
    {

        if(context.performed)
            NotifyEvent(HASH_L_MOUSE_BUTTON, MouseInputType.Down);
        else
            NotifyEvent(HASH_L_MOUSE_BUTTON, MouseInputType.Up);

    }

    public void OnMouseRightButton(InputAction.CallbackContext context)
    {

        if (context.performed)
            NotifyEvent(HASH_R_MOUSE_BUTTON, MouseInputType.Down);
        else
            NotifyEvent(HASH_R_MOUSE_BUTTON, MouseInputType.Up);

    }

    private void OnDestroy()
    {

        _input.Dispose();

    }

}