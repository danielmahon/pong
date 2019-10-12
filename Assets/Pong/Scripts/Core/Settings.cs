using UnityEngine;

namespace Pong {

  [CreateAssetMenu(fileName = "BounceSettings", menuName = "Pong/Settings/BounceSettings")]
  public class BounceSettings : ScriptableObject {
    public float maxSpeed = 12f;
  }

}