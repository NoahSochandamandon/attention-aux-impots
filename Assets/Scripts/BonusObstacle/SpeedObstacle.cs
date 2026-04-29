using UnityEngine;

public class SpeedObstacle : BonusObstacle
{
  [SerializeField]
  protected float SpeedMultiplier = 1.5f;

  private void Awake()
  {
    Speed *= 1.5f;
  }

  protected override void Update()
  {
    base.Update();
  }

  public override int Explode()
  {
    Destroy(gameObject);
    return (int)SpeedMultiplier;
  }
}
