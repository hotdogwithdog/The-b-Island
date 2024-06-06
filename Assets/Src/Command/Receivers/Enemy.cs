using UnityEngine;

namespace Command.Receivers
{
    public class Enemy : MonoBehaviour, Interfaces.IMoveableReceiver
    {
        public bool IsGoingToPointLeft { get; set; } = true;

        [SerializeField] private float _speed = 8;
        private Vector2 _inputDirection;
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;
        private bool _isLookingRight = true;
        private Vector2 _currentVelocity;

        public Transform positionLeft;
        public Transform positionRight;


        [SerializeField] private float _attackDamage = 25.0f;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }


        private void FixedUpdate()
        {
            _currentVelocity.x = _inputDirection.x * _speed;

            _rigidbody2D.velocity = new Vector2(_currentVelocity.x, _rigidbody2D.velocity.y);
        }

        private void Update()
        {
            if (_rigidbody2D.velocity.x > 0.1) _isLookingRight = true;
            else if (_rigidbody2D.velocity.x < -0.1) _isLookingRight = false;

            if (_isLookingRight)
            {
                _spriteRenderer.flipX = true;
            }
            else
            {
                _spriteRenderer.flipX = false;
            }
        }




        public void Move(Vector2 direction)
        {
            Debug.Log("SI: " + direction.x);

            _inputDirection = direction;
        }
    }
}
