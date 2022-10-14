using UnityEngine;

public class HandMover : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    [SerializeField] private float _accelerationSensivity;
    [SerializeField] private float _maxVelocity;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
         float unityMove = Input.GetAxis("Horizontal");
        float androidMove = Input.acceleration.x;
#if UNITY_EDITOR
        _rb.velocity = new Vector2(unityMove * _speed, _rb.velocity.y);
#elif UNITY_ANDROID
        _rb.velocity = new Vector2(androidMove * _speed * _accelerationSensivity, _rb.velocity.y);
#endif
        _rb.velocity = new Vector2(_rb.velocity.x ,Mathf.Clamp(_rb.velocity.y, -_maxVelocity/2, _maxVelocity));

    }
}
