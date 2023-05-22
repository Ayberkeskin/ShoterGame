//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/InputSystem/Player Input.inputactions
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

public partial class @PlayerInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Input"",
    ""maps"": [
        {
            ""name"": ""PlayerController"",
            ""id"": ""40ea5400-2b09-487d-9627-14dfacb5ea7d"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""b363460c-4b47-4d2a-b68a-8cfdf49d6763"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""3b7ecada-7dde-44c2-9e53-f42558617ad3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Holster"",
                    ""type"": ""Button"",
                    ""id"": ""8422fd56-3aa9-44bb-8005-8b3d59561051"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""7ecda7d2-c5af-472c-8b8d-a260e6b6bb60"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""47211f48-dc6e-46e0-a772-1f2f9249b38e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0bada9fd-db29-4c9e-b355-785c18329d3e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3740c1c6-816a-4ef7-b3ef-1cb4edcaab3e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b009ad5d-979d-4ed7-a60c-9b41bcbedf80"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b7aef745-8d15-441b-b5bd-51c129a2672c"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa87ca93-e688-4b07-8c7e-3e53f0c6a359"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Holster"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""CameraController"",
            ""id"": ""a2b265f3-c293-476f-b35d-f5b0b3fe54f7"",
            ""actions"": [
                {
                    ""name"": ""Zoom"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d2262f03-eb89-4d62-b317-e65c1e954799"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": ""Normalize(min=-1,max=1)"",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2e3c8fc3-46d2-403e-a760-c77efe980198"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerController
        m_PlayerController = asset.FindActionMap("PlayerController", throwIfNotFound: true);
        m_PlayerController_Movement = m_PlayerController.FindAction("Movement", throwIfNotFound: true);
        m_PlayerController_Run = m_PlayerController.FindAction("Run", throwIfNotFound: true);
        m_PlayerController_Holster = m_PlayerController.FindAction("Holster", throwIfNotFound: true);
        // CameraController
        m_CameraController = asset.FindActionMap("CameraController", throwIfNotFound: true);
        m_CameraController_Zoom = m_CameraController.FindAction("Zoom", throwIfNotFound: true);
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

    // PlayerController
    private readonly InputActionMap m_PlayerController;
    private List<IPlayerControllerActions> m_PlayerControllerActionsCallbackInterfaces = new List<IPlayerControllerActions>();
    private readonly InputAction m_PlayerController_Movement;
    private readonly InputAction m_PlayerController_Run;
    private readonly InputAction m_PlayerController_Holster;
    public struct PlayerControllerActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerControllerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerController_Movement;
        public InputAction @Run => m_Wrapper.m_PlayerController_Run;
        public InputAction @Holster => m_Wrapper.m_PlayerController_Holster;
        public InputActionMap Get() { return m_Wrapper.m_PlayerController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControllerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerControllerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerControllerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerControllerActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Run.started += instance.OnRun;
            @Run.performed += instance.OnRun;
            @Run.canceled += instance.OnRun;
            @Holster.started += instance.OnHolster;
            @Holster.performed += instance.OnHolster;
            @Holster.canceled += instance.OnHolster;
        }

        private void UnregisterCallbacks(IPlayerControllerActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Run.started -= instance.OnRun;
            @Run.performed -= instance.OnRun;
            @Run.canceled -= instance.OnRun;
            @Holster.started -= instance.OnHolster;
            @Holster.performed -= instance.OnHolster;
            @Holster.canceled -= instance.OnHolster;
        }

        public void RemoveCallbacks(IPlayerControllerActions instance)
        {
            if (m_Wrapper.m_PlayerControllerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerControllerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerControllerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerControllerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerControllerActions @PlayerController => new PlayerControllerActions(this);

    // CameraController
    private readonly InputActionMap m_CameraController;
    private List<ICameraControllerActions> m_CameraControllerActionsCallbackInterfaces = new List<ICameraControllerActions>();
    private readonly InputAction m_CameraController_Zoom;
    public struct CameraControllerActions
    {
        private @PlayerInput m_Wrapper;
        public CameraControllerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Zoom => m_Wrapper.m_CameraController_Zoom;
        public InputActionMap Get() { return m_Wrapper.m_CameraController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraControllerActions set) { return set.Get(); }
        public void AddCallbacks(ICameraControllerActions instance)
        {
            if (instance == null || m_Wrapper.m_CameraControllerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CameraControllerActionsCallbackInterfaces.Add(instance);
            @Zoom.started += instance.OnZoom;
            @Zoom.performed += instance.OnZoom;
            @Zoom.canceled += instance.OnZoom;
        }

        private void UnregisterCallbacks(ICameraControllerActions instance)
        {
            @Zoom.started -= instance.OnZoom;
            @Zoom.performed -= instance.OnZoom;
            @Zoom.canceled -= instance.OnZoom;
        }

        public void RemoveCallbacks(ICameraControllerActions instance)
        {
            if (m_Wrapper.m_CameraControllerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICameraControllerActions instance)
        {
            foreach (var item in m_Wrapper.m_CameraControllerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CameraControllerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CameraControllerActions @CameraController => new CameraControllerActions(this);
    public interface IPlayerControllerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnHolster(InputAction.CallbackContext context);
    }
    public interface ICameraControllerActions
    {
        void OnZoom(InputAction.CallbackContext context);
    }
}
