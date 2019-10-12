using UnityEngine;
using UnityEngine.Assertions;

namespace Pong {

    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class BallEntity : MonoBehaviour, ICanBounce {

        [SerializeField]
        private BounceSettings settings = null;

        private float speed;

        public Rigidbody2D rigidBody2D { get; private set; }

        void Awake() {
            Assert.IsNotNull(settings, "Missing BounceSettings!");

            rigidBody2D = GetComponent<Rigidbody2D>();
            // Set initial speed and velocity
            speed = 4f;
            rigidBody2D.velocity = new Vector2(0.5f, 0.5f) * speed;
        }

        public void OnTriggerEnter2D(Collider2D other) {
            Logic.Bounce.Process(this, other);
        }

        public float AddSpeed(float amount) {
            speed = Mathf.Clamp(speed + amount, 0, settings.maxSpeed);
            return speed;
        }
    }
}