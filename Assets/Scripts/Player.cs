using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float Speed = 10f;

    [SerializeField]
    private float SpeedDecrease = 0.9f;

    [SerializeField]
    private Rigidbody Body;

    [SerializeField]
    private Animator SpriteAnimator;

    private Vector2 _movement;

    [SerializeField]
    private int HP = 10;

    [SerializeField]
    private Slider HPSlider;

    [SerializeField]
    private GameObject GameOverScreen;

    void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        if (_movement.magnitude > 0)
        {

            Vector3 direction = new Vector3(_movement.x, _movement.y, 0);

            Body.AddForce(direction * Speed);

            if (SpriteAnimator != null)
                SpriteAnimator.SetBool("isWalking", true);

            if (_movement.x != 0)
            {
                SpriteAnimator.GetComponent<SpriteRenderer>().flipX = (_movement.x > 0);
            }
        }
        else
        {
            Body.linearVelocity *= SpeedDecrease;

            if (SpriteAnimator != null)
                SpriteAnimator.SetBool("isWalking", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Obstacle o = other.GetComponent<Obstacle>();
        if (o != null)
        {
            int damages = o.Explode();
            HP -= damages;
            HPSlider.value = HP;
            if (HP <= 0)
            {
                if (SpriteAnimator != null) SpriteAnimator.SetBool("isWalking", false);

                enabled = false;
                GameOverScreen.SetActive(true);
            }
        }
    }
}