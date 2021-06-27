using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Controls")]
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;

    private const float _constSpeed = 100;


    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(-_speed * _constSpeed * Time.fixedDeltaTime, 0);
    }
}
