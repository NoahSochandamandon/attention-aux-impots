using UnityEngine;

public class HealObstacle : BonusObstacle
{

  private void Awake()
  {
    Damages = -1;
  }

  protected override void Update()
  {
    base.Update();
  }
}
