using UnityEngine;

namespace Pong {

  public interface ICanBounce {
    Rigidbody2D rigidBody2D { get; }
    float AddSpeed(float amount);
  }

}