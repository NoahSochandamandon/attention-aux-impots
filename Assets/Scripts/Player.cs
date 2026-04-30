using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float Speed = 10f;

    private float _baseSpeed;

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

    private void Awake()
    {
        _baseSpeed = Speed;
    }

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
        Obstacle obstacle = other.GetComponent<Obstacle>();

        if (obstacle != null)
        {
            obstacle.ApplyEffect(this);
        }
    }

    public void ModifyHP(int amount)
    {
        HP += amount;
        HPSlider.value = HP;
        isDead();
    }

    public void ApplySpeedBoost(float mult, float dur)
    {
        StartCoroutine(SpeedBoostRoutine(mult, dur));
    }

    private void isDead()
    {
        if (HP <= 0)
        {
            enabled = false;
            GameOverScreen.SetActive(true);
            if (HP <= 0)
            {
                if (SpriteAnimator != null) SpriteAnimator.SetBool("isWalking", false);

                enabled = false;
                GameOverScreen.SetActive(true);
            }
        }
    }

    private IEnumerator SpeedBoostRoutine(float mult, float dur)
    {
        Speed = Speed * mult;

        yield return new WaitForSeconds(dur);

        Speed = _baseSpeed;
    }
}