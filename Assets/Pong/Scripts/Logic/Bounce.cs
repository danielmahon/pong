using UnityEngine;

namespace Pong.Logic {

  public static class Bounce {

    private enum WallType {
      VERTICAL,
      HORIZONTAL
    }

    public static void Process(ICanBounce entity, Collider2D collider) {
      Vector2 velocity = entity.rigidBody2D.velocity;
      Vector3 position = collider.transform.position;
      WallType wallType = position.x != 0 ? WallType.VERTICAL : WallType.HORIZONTAL;

      Debug.Log($"[Logic.Bounce] Detected collision on {wallType} wall.");

      // Increase entity's speed after every collision
      float newSpeed = entity.AddSpeed(1f);

      // Update entity's velocity based on collision angle
      Vector2 newDirection = new Vector2(
        wallType == WallType.VERTICAL ? -velocity.x : velocity.x,
        wallType == WallType.HORIZONTAL ? -velocity.y : velocity.y
      ).normalized;

      entity.rigidBody2D.velocity = newDirection * newSpeed;

    }

  }
}