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

    [SerializeField]
    private Transform MuscleTransform;

    private float _nextSpawn;
    private int _spawnCount = 0;

    [SerializeField]
    private const int DAMAGE_TO_BONUS_RATIO = 9;

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
            prefab = BonusObstacles[Random.Range(0, BonusObstacles.Length)];
        }
        else
        {
            prefab = DamageObstacle;
        }

        Vector3 spawnLocalPos = new Vector3(
            Random.Range(-SpawnBounds.x, SpawnBounds.x),
            Random.Range(-SpawnBounds.y, SpawnBounds.y),
            0);

        if (MuscleTransform != null)
        {
            MuscleTransform.position = transform.TransformPoint(spawnLocalPos);

            Animator mAnim = MuscleTransform.GetComponentInChildren<Animator>();
            if (mAnim != null)
            {
                mAnim.Play("Attack_1", -1, 0f);
            }
        }

        Obstacle o = Instantiate(prefab, transform);
        o.transform.localPosition = spawnLocalPos;

        _spawnCount++;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position, (Vector3)SpawnBounds);
    }
}