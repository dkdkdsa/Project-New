//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/99_Settings/Input/InputMap.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputMap: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMap"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""ed85bdfd-e5b2-4e23-bdb4-98ccea06b9f7"",
            ""actions"": [
                {
                    ""name"": ""Mouse"",
                    ""type"": ""Value"",
                    ""id"": ""e07e1f51-8721-4edc-befc-872fad4572b5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MouseLeftButton"",
                    ""type"": ""Button"",
                    ""id"": ""1dcb39b0-3910-4e83-a209-816b27895b08"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseRightButton"",
                    ""type"": ""Button"",
                    ""id"": ""846acf77-94c7-41bf-b792-f8f8a81e1c71"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f0ed743e-9abf-4a2c-99bd-191257055524"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KAM"",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4974fd4-f13a-46f2-aebd-a2fc3c247fab"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KAM"",
                    ""action"": ""MouseLeftButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b43ba9bb-46e7-4b8b-9164-782862fb1c4b"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KAM"",
                    ""action"": ""MouseRightButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KAM"",
            ""bindingGroup"": ""KAM"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Mouse = m_Player.FindAction("Mouse", throwIfNotFound: true);
        m_Player_MouseLeftButton = m_Player.FindAction("MouseLeftButton", throwIfNotFound: true);
        m_Player_MouseRightButton = m_Player.FindAction("MouseRightButton", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Mouse;
    private readonly InputAction m_Player_MouseLeftButton;
    private readonly InputAction m_Player_MouseRightButton;
    public struct PlayerActions
    {
        private @InputMap m_Wrapper;
        public PlayerActions(@InputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Mouse => m_Wrapper.m_Player_Mouse;
        public InputAction @MouseLeftButton => m_Wrapper.m_Player_MouseLeftButton;
        public InputAction @MouseRightButton => m_Wrapper.m_Player_MouseRightButton;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Mouse.started += instance.OnMouse;
            @Mouse.performed += instance.OnMouse;
            @Mouse.canceled += instance.OnMouse;
            @MouseLeftButton.started += instance.OnMouseLeftButton;
            @MouseLeftButton.performed += instance.OnMouseLeftButton;
            @MouseLeftButton.canceled += instance.OnMouseLeftButton;
            @MouseRightButton.started += instance.OnMouseRightButton;
            @MouseRightButton.performed += instance.OnMouseRightButton;
            @MouseRightButton.canceled += instance.OnMouseRightButton;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Mouse.started -= instance.OnMouse;
            @Mouse.performed -= instance.OnMouse;
            @Mouse.canceled -= instance.OnMouse;
            @MouseLeftButton.started -= instance.OnMouseLeftButton;
            @MouseLeftButton.performed -= instance.OnMouseLeftButton;
            @MouseLeftButton.canceled -= instance.OnMouseLeftButton;
            @MouseRightButton.started -= instance.OnMouseRightButton;
            @MouseRightButton.performed -= instance.OnMouseRightButton;
            @MouseRightButton.canceled -= instance.OnMouseRightButton;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KAMSchemeIndex = -1;
    public InputControlScheme KAMScheme
    {
        get
        {
            if (m_KAMSchemeIndex == -1) m_KAMSchemeIndex = asset.FindControlSchemeIndex("KAM");
            return asset.controlSchemes[m_KAMSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMouse(InputAction.CallbackContext context);
        void OnMouseLeftButton(InputAction.CallbackContext context);
        void OnMouseRightButton(InputAction.CallbackContext context);
    }
}
