using UnityEngine;

namespace Pong.Logic {

  public static class Bounce {

    public static void Process(Rigidbody2D rb2D, Collision2D collision, Vector2 lastFrameVelocity) {

      // Calculate bounce angle
      Vector2 inDirection = lastFrameVelocity.normalized;
      Vector2 inNormal = collision.contacts[0].normal;
      Vector2 newDirection = Vector2.Reflect(inDirection, inNormal).normalized;

      // Increase speed after every bounce
      float newSpeed = Mathf.Clamp(lastFrameVelocity.magnitude + 1f, 4f, 12f);

      rb2D.velocity = newDirection * newSpeed;
    }

  }

  public static class Move {

    public static void Process(Transform transform, Vector3 direction, float speed, float limit) {
      transform.Translate(direction * speed * Time.deltaTime);
      if (transform.position.y < -limit) {
        transform.position = new Vector3(transform.position.x, -limit, 0);
      }
      if (transform.position.y > limit) {
        transform.position = new Vector3(transform.position.x, limit, 0);
      }

    }

  }
}