using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    protected float Speed;

    [SerializeField]
    protected float DestroyDistance;

    [SerializeField]
    protected int Damages;

    protected virtual void Update()
    {
        transform.position += new Vector3(0, 0, -Speed * Time.deltaTime);

        FinCourse();
    }

    protected void FinCourse()
    {
        if (transform.position.z < DestroyDistance)
        {
            Destroy(gameObject);
        }

    }

    public int Explode()
    {
        Destroy(gameObject);
        return Damages;
    }
}
