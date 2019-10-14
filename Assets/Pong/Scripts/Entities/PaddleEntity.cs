using Pong.Core;
using UnityEngine;

namespace Pong {

    public class PaddleEntity : MonoBehaviour {

        [SerializeField]
        private float speed = 10f;
        [SerializeField]
        private float limit = 3.65f;

        private Vector3 direction;

        void OnEnable() {
            InputManager.OnMove += ChangeDirection;
        }
        void OnDisable() {
            InputManager.OnMove -= ChangeDirection;
        }

        void ChangeDirection(Vector3 newDirection) {
            direction = newDirection;
        }

        private void Update() {
            Logic.Move.Process(this.transform, direction, speed, limit);
        }

    }
}