using System.Collections.Generic;
using UnityEngine;

namespace Pong {

  public enum PlayerType {
    PLAYER_1,
    PLAYER_2
  }

  [CreateAssetMenu(fileName = "Settings", menuName = "Pong/Settings/New Settings")]
  public class Settings : ScriptableObject {
    public float maxSpeed = 12f;

    public Dictionary<PlayerType, int> scores = new Dictionary<PlayerType, int>();

    public void OnEnable() {
      // Initialize dictionary with starting player scores
      string[] PlayerTypeNames = System.Enum.GetNames(typeof(PlayerType));
      for (int i = 0; i < PlayerTypeNames.Length; i++) {
        PlayerType type = (PlayerType) System.Enum.Parse(typeof(PlayerType), PlayerTypeNames[i]);
        scores[type] = 0;
      }
    }
  }

}