//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/StarterAssets/InputSystem/ShootInput.inputactions
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

public partial class @ShootInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @ShootInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ShootInput"",
    ""maps"": [
        {
            ""name"": ""Shoot"",
            ""id"": ""8c496232-89c0-46a2-8619-ac154218723b"",
            ""actions"": [
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""35c29d8d-e0a9-4ea6-b846-7330615129ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""32dd5b43-9a30-446a-bb37-68a9241b2c38"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3bb18a10-5bd6-408c-9d72-e3917ea9abc9"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Shoot
        m_Shoot = asset.FindActionMap("Shoot", throwIfNotFound: true);
        m_Shoot_Fire = m_Shoot.FindAction("Fire", throwIfNotFound: true);
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

    // Shoot
    private readonly InputActionMap m_Shoot;
    private IShootActions m_ShootActionsCallbackInterface;
    private readonly InputAction m_Shoot_Fire;
    public struct ShootActions
    {
        private @ShootInput m_Wrapper;
        public ShootActions(@ShootInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire => m_Wrapper.m_Shoot_Fire;
        public InputActionMap Get() { return m_Wrapper.m_Shoot; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShootActions set) { return set.Get(); }
        public void SetCallbacks(IShootActions instance)
        {
            if (m_Wrapper.m_ShootActionsCallbackInterface != null)
            {
                @Fire.started -= m_Wrapper.m_ShootActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_ShootActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_ShootActionsCallbackInterface.OnFire;
            }
            m_Wrapper.m_ShootActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
            }
        }
    }
    public ShootActions @Shoot => new ShootActions(this);
    public interface IShootActions
    {
        void OnFire(InputAction.CallbackContext context);
    }
}
