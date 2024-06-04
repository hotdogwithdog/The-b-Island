using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command.Receivers
{
    public class Player : MonoBehaviour, Interfaces.IMoveableReceiver, Interfaces.IJumperReceiver
    {
        [SerializeField] private float _speed = 8;
        [SerializeField] private Transform _footPosition;
        [SerializeField] private float _jumpForce = 3.0f;

        private SpriteRenderer _spriteRenderer;
        private Animator _animator;
        private bool _isLookingRight = true;

        private Vector2 _currentVelocity;
        private Vector2 _inputDirection;
        private float _inputFactor;

        private Rigidbody2D _rigidbody2D;

        private bool _isGrounded;
        private bool _isJumping;

        

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            // Movimiento
            _currentVelocity.x = _inputFactor * _inputDirection.x * _speed;

            // Salto
            if (_isJumping && _isGrounded)
            {
                float jumpForce = Mathf.Sqrt(_jumpForce * -2.0f * (Physics2D.gravity.y * _rigidbody2D.gravityScale));
                _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                _isJumping = false;
            }


            // Actualización en sí
            _rigidbody2D.velocity = new Vector2(_currentVelocity.x, _rigidbody2D.velocity.y);
        }
        private void Update()
        {
            _isGrounded = Physics2D.OverlapCircle(_footPosition.position, 0.3f, LayerMask.GetMask("Floor"));

            _inputFactor = Mathf.Abs(Input.GetAxis("Horizontal"));

            // Le pasamos a los valores del animador los valores del jugador
            _animator.SetFloat("Speed", Mathf.Abs(_rigidbody2D.velocity.x));
            _animator.SetBool("isGrounded", _isGrounded);

            // Miramos si debemos voltear o no el sprite
            if (_rigidbody2D.velocity.x > 0.1) _isLookingRight = true;
            else if (_rigidbody2D.velocity.x < -0.1) _isLookingRight = false;

            if (_isLookingRight) _spriteRenderer.flipX = false;
            else _spriteRenderer.flipX = true;

        }

        public void Move(Vector2 direction)
        {
            _inputDirection = direction;
        }

        public void Jump()
        {
            if (_isGrounded)
            {
                _isJumping = true;
                _isGrounded = false;
            }
        }
    }
}

