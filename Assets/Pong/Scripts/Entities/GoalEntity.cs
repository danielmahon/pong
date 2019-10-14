using UnityEngine;
using UnityEngine.Assertions;

namespace Pong {

    [RequireComponent(typeof(Collider2D))]
    public class GoalEntity : MonoBehaviour {

        [SerializeField]
        private PlayerType player;
        [SerializeField]
        private Settings settings = null;

        void Awake() {
            Assert.IsNotNull(settings, "Missing Settings!");
        }

        private void OnCollisionEnter2D(Collision2D other) {
            BallEntity ball = other.gameObject.GetComponent<BallEntity>();
            if (ball != null) {
                // Increase score
                settings.scores[player] += 1;
                // Reset position and speed
                ball.SetSpeed(5f);
                ball.gameObject.transform.position = Vector3.zero;
            }
        }
    }

}