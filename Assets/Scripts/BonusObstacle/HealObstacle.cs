using UnityEngine;

public class HealObstacle : BonusObstacle
{

  [SerializeField] private int heal = 1;

  public override void ApplyEffect(Player player)
  {
    player.ModifyHP(heal);
    Destroy(gameObject);
  }

}
