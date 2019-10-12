using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pong.Core {
    public class BootManager : MonoBehaviour {

        public static BootManager Instance { get; private set; }

        private void Awake() {
            if (Instance != null) {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        // Start is called before the first frame update
        void Start() {
            Launch();
        }

        public void Launch() {
            // Unload all scenes except Boot
            for (int i = 0; i < SceneManager.sceneCount; i++) {
                Scene scene = SceneManager.GetSceneByBuildIndex(i);
                if (scene.name != gameObject.scene.name) {
                    SceneManager.UnloadSceneAsync(i);
                }
            }
            SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
        }
        public void Quit() {
            SceneManager.UnloadSceneAsync("Game");
        }
    }
}