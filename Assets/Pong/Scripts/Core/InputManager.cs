using UnityEngine;
using UnityEngine.InputSystem;

namespace Pong.Core {
    public class InputManager : MonoBehaviour {

        public static InputManager Instance { get; private set; }

        public delegate void HandleMove(Vector3 direction);
        public static event HandleMove OnMove;

        private void Awake() {
            if (Instance != null) {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        void Update() {
            if (Keyboard.current[Key.Escape].wasPressedThisFrame) {
                BootManager.Instance.Quit();
            }
            if (Keyboard.current[Key.L].wasPressedThisFrame) {
                BootManager.Instance.Launch();
            }
            if (Keyboard.current[Key.W].wasPressedThisFrame) {
                OnMove(Vector3.up);

            } else if (Keyboard.current[Key.W].wasReleasedThisFrame) {
                OnMove(Vector3.zero);
            }
            if (Keyboard.current[Key.S].wasPressedThisFrame) {
                OnMove(Vector3.down);

            } else if (Keyboard.current[Key.S].wasReleasedThisFrame) {
                OnMove(Vector3.zero);
            }
        }
    }
}