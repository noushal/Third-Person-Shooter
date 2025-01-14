using UnityEngine;
using UnityEngine.SceneManagement;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
using UnityEditor.SceneManagement;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
        public bool aim;
		public bool shoot;

        [Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM

        private void Start() {
            SetCursorState();
        }

        public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

        public void OnAim(InputValue value) 
		{
            AimInput(value.isPressed);
        }

        public void OnShoot(InputValue value) 
		{
            ShootInput(value.isPressed);
        }
#endif


        public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

        public void AimInput(bool newAimState) 
		{
            aim = newAimState;
        }

        public void ShootInput(bool newShootState) 
		{
            shoot = newShootState;
        }

        private void OnApplicationFocus(bool hasFocus)
		{
            SetCursorState();
        }

        private void SetCursorState() {
            string sceneName = SceneManager.GetActiveScene().name;

            if (sceneName == "Playground") {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;              
            } else if (sceneName == "WinningScene") {
                Cursor.lockState = CursorLockMode.None;   
                Cursor.visible = true;                     
            } else {
                Cursor.lockState = CursorLockMode.None;    
                Cursor.visible = true;                  
            }
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
            SetCursorState();
        }
        private void OnEnable() {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable() {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
	
}