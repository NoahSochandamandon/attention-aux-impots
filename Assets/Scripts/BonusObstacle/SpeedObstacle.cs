using UnityEngine;

public class SpeedObstacle : BonusObstacle
{
  private void Awake()
  {
    Speed = 1.5f;
  }

  protected override void Update()
  {
    base.Update();
  }
}
