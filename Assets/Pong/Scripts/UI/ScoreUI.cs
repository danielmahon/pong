using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace Pong.UI {

    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ScoreUI : MonoBehaviour {
        [SerializeField]
        private Settings settings = null;
        [SerializeField]
        private PlayerType player;

        private TextMeshProUGUI scoreText;

        private void Awake() {
            Assert.IsNotNull(settings, "Missing Settings!");
            scoreText = GetComponent<TextMeshProUGUI>();
        }

        private void OnGUI() {
            scoreText.text = settings.scores[player].ToString();
        }

    }

}