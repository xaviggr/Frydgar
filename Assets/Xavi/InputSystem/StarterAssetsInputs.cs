using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
using System;
#endif

namespace StarterAssets
{
    public class StarterAssetsInputs : MonoBehaviour
    {
        public event Action Inventory = delegate { };
        public event Action Pause = delegate { };
        public event Action Interact = delegate { };
        public event Action MapInteract = delegate { };
        public event Action Attack = delegate { };
        public event Action<bool> Shield = delegate { };
        public event Action Armed = delegate { };

        [Header("Character Input Values")]
        public Vector2 move;
        public Vector2 look;
        public bool jump;
        public bool shield;
        public bool view;
        public bool sprint;
        public bool useMap;

        [Header("Movement Settings")]
        public bool analogMovement;

        void Start()
        {
            useMap = true;
        }

#if !UNITY_IOS || !UNITY_ANDROID
        [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;
#endif

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED

        private static StarterAssetsInputs _instance;
        public static StarterAssetsInputs Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<StarterAssetsInputs>();
                }
                return _instance;
            }
        }

        public void OnMove(InputValue value)
        {
            MoveInput(value.Get<Vector2>());
        }

        public void OnLook(InputValue value)
        {
            if (cursorInputForLook)
            {
                LookInput(value.Get<Vector2>());
            }
        }

        public void OnJump(InputValue value)
        {
            JumpInput(value.isPressed);
        }

        public void OnShield(InputValue value)
        {
            ShieldInput(value.isPressed);
            Shield(value.isPressed);
        }

        public void OnHideUnHideWeapon(InputValue value)
        {
            HideUnHideWeapon(value.isPressed);
        }

        public void OnAttack(InputValue value)
        {
            AttackInput(value.isPressed);
        }

        public void OnInventory(InputValue value)
        {
            InventoryInput(value.isPressed);
        }

        public void OnPause(InputValue value)
        {
            PauseInput(value.isPressed);
        }

        public void OnInteract(InputValue value)
        {
            InteractInput(value.isPressed);
        }

        public void OnView(InputValue value)
        {
            ViewInput(value.isPressed);
        }

        public void OnSprint(InputValue value)
        {
            SprintInput(value.isPressed);
        }

        public void OnMapControl(InputValue value)
        {
            MapInput(value.isPressed);
        }

#else
	// old input sys if we do decide to have it (most likely wont)...
#endif


        public void MoveInput(Vector2 newMoveDirection)
        {
            move = newMoveDirection;
        }

        public void LookInput(Vector2 newLookDirection)
        {
            look = newLookDirection;
        }

        public void ViewInput(bool newViewState)
        {
            view = newViewState;
        }

        public void JumpInput(bool newJumpState)
        {
            jump = newJumpState;
        }

        public void ShieldInput(bool newShieldState)
        {
            if(StatsPlayerController.Instance) StatsPlayerController.Instance.player_stats.inmortal = newShieldState;
            shield = newShieldState;
        }

        public void HideUnHideWeapon(bool newWeaponState)
        {
            if (newWeaponState) Armed();
        }

        public void InventoryInput(bool newInventoryState)
        {
            if (newInventoryState) Inventory();
        }

        public void PauseInput(bool newPauseState)
        {
            if (newPauseState) Pause();
        }

        public void InteractInput(bool newInteractState)
        {
            if (newInteractState) Interact();
        }

        public void SprintInput(bool newSprintState)
        {
            sprint = newSprintState;
        }

        public void AttackInput(bool newAttackState)
        {
            if (newAttackState) Attack();
        }

        public void MapInput(bool newMapState)
        {
            MapInteract();
            useMap = !newMapState;
        }

#if !UNITY_IOS || !UNITY_ANDROID

        private void OnApplicationFocus(bool hasFocus)
        {
            //SetCursorState(cursorLocked);
        }

        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }

#endif

    }

}