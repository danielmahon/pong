using UnityEngine;
using UnityEngine.InputSystem;

namespace Pong.Core {
    public class InputManager : MonoBehaviour {

        public static InputManager Instance { get; private set; }

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
        }
    }
}