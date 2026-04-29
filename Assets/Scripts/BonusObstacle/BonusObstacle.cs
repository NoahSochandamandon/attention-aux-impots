using UnityEngine;

public class BonusObstacle : Obstacle
{
  private void Awake()
  {
    Damages = 0;
  }

  protected override void Update()
  {

    base.Update();

  }
}
