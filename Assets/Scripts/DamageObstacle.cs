using UnityEngine;

public class DamageObstacle : Obstacle
{

  [SerializeField] private int damages = 1;

  public override void ApplyEffect(Player player)
  {
    player.ModifyHP(-damages);
    Destroy(gameObject);
  }
}
