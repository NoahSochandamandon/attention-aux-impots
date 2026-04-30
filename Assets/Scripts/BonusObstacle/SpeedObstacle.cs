using UnityEngine;

public class SpeedObstacle : BonusObstacle
{
  [SerializeField] private float multiplier = 2f;
  [SerializeField] private float duration = 10f;

  private void Awake()
  {
    Speed *= 1.5f;
  }

  public override void ApplyEffect(Player player)
  {
    player.ApplySpeedBoost(multiplier, duration);
    Destroy(gameObject);
  }
}
