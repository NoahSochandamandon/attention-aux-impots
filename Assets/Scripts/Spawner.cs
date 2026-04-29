using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Obstacle DamageObstacle;

    [SerializeField]
    private Obstacle[] BonusObstacles;

    [SerializeField]
    private Vector2 SpawnBounds;

    [SerializeField]
    private Vector2 SpawnDelay;

    private float _nextSpawn;
    private int _spawnCount = 0;

    [SerializeField]
    private const int DAMAGE_TO_BONUS_RATIO = 9;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _nextSpawn)
        {
            SpawnObstacle();

            _nextSpawn = Time.time + Random.Range(SpawnDelay.x, SpawnDelay.y);
        }
    }

    private void SpawnObstacle()
    {
        Obstacle prefab;
        if (_spawnCount % (DAMAGE_TO_BONUS_RATIO + 1) == DAMAGE_TO_BONUS_RATIO)
        {
            // Choose a random bonus obstacle from the array
            prefab = BonusObstacles[Random.Range(0, BonusObstacles.Length)];
        }
        else
        {
            prefab = DamageObstacle;
        }

        Obstacle o = Instantiate(prefab, transform);
        o.transform.localPosition = new Vector3(
            Random.Range(-SpawnBounds.x, SpawnBounds.x),
            Random.Range(-SpawnBounds.y, SpawnBounds.y),
            0);

        _spawnCount++;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawCube(transform.position, (Vector3)SpawnBounds);
    }
}
