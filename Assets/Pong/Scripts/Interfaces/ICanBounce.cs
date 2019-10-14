using UnityEngine;

namespace Pong {

  public interface ICanBounce {
    GameObject gameObject { get; }
    Rigidbody2D rb2D { get; }
  }

}