using UnityEngine;

public class AttackObstacle : BonusObstacle
{
  [SerializeField] private float speedMultiplier = 5f;
  [SerializeField] private int damagesToSpawner = 1;

  private bool _isReflected = false;
  private Rigidbody _rb;

  private void Awake()
  {
    _rb = GetComponent<Rigidbody>();
  }

  public override void ApplyEffect(Player player)
  {
    if (_isReflected) return;

    _isReflected = true;

    if (_rb != null)
    {
      Vector3 currentVelocity = _rb.linearVelocity;
      _rb.linearVelocity = new Vector3(currentVelocity.x, currentVelocity.y, -currentVelocity.z * speedMultiplier);
    }

    if (TryGetComponent<Renderer>(out var renderer))
    {
      renderer.material.color = Color.red;
    }
  }

  protected override void Update()
  {
    float directionZ = _isReflected ? 1f : -1f;
    float currentSpeed = _isReflected ? Speed * speedMultiplier : Speed;
    transform.position += new Vector3(0, 0, directionZ * currentSpeed * Time.deltaTime);
    FinCourse();
  }

  private void OnTriggerEnter(Collider other)
  {
    if (_isReflected && other.CompareTag("Spawner"))
    {
      Spawner spawner = other.GetComponent<Spawner>();

      if (spawner != null)
      {
        spawner.TakeDamage(damagesToSpawner);
      }

      Debug.Log("Le Spawner a manger une attaque réfléchie et a perdu " + damagesToSpawner + " points de vie !");
      Destroy(gameObject);
    }
  }
}