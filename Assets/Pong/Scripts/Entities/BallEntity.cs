using UnityEngine;
using UnityEngine.Assertions;

namespace Pong {

    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class BallEntity : MonoBehaviour {

        [SerializeField]
        private Settings settings = null;

        private float speed;
        private Vector2 lastFrameVelocity;
        private Rigidbody2D rb2D;

        public void SetSpeed(float newSpeed) {
            lastFrameVelocity = lastFrameVelocity * (newSpeed / speed);
            speed = newSpeed;
        }

        void Awake() {
            Assert.IsNotNull(settings, "Missing Settings!");
            rb2D = GetComponent<Rigidbody2D>();
            // Set initial speed and velocity
            speed = 5f;
            rb2D.velocity = new Vector2(0.5f, 0.5f) * speed;
        }

        private void Update() {
            lastFrameVelocity = rb2D.velocity;
        }

        public void OnCollisionEnter2D(Collision2D collision) {
            Logic.Bounce.Process(rb2D, collision, lastFrameVelocity);
        }

    }
}