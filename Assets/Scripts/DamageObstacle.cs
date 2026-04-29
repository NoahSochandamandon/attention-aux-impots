using UnityEngine;

public class DamageObstacle : Obstacle
{
  private void Awake()
  {
    Damages = 2;
  }

  protected override void Update()
  {
    base.Update();
  }

}
