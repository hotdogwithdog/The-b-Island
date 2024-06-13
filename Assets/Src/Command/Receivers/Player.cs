using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Command.Receivers
{
    public class Player : Entity.AEntity, Interfaces.IMoveableReceiver, Interfaces.IJumperReceiver, Interfaces.IAttackReceiver, Observer.Observers.IObserver_void
    {
        [SerializeField] private float _speed = 8;
        [SerializeField] private Transform _footPosition;
        [SerializeField] private float _jumpForce = 3.0f;

        private SpriteRenderer _spriteRenderer;
        private Animator _animator;
        private bool _isLookingRight = true;
        [SerializeField] private Animator _swordAnimator;
        [SerializeField] private SpriteRenderer _swordSpriteRenderer;

        private Vector2 _currentVelocity;
        private Vector2 _inputDirection;
        private float _inputFactor;

        private Rigidbody2D _rigidbody2D;

        private bool _isGrounded;
        private bool _isJumping;

        [SerializeField] private Transform _swordPosition;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();

            GameObject.Find("DeathLimit").GetComponent<Limits.FallDeath>().Suscribe(this);
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

            if (_isLookingRight)
            {
                _spriteRenderer.flipX = false;
                _swordSpriteRenderer.flipX = false;
                _swordPosition.localPosition = new Vector3(0.758f, _swordPosition.localPosition.y, _swordPosition.localPosition.z);
            }
            else
            {
                _spriteRenderer.flipX = true;
                _swordSpriteRenderer.flipX = true;
                _swordPosition.localPosition = new Vector3(-0.758f, _swordPosition.localPosition.y, _swordPosition.localPosition.z);
            }
            

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

        public void Attack()
        {
            _swordAnimator.SetTrigger("Attack");
            // Utilizamos la mitad escala local, puesto que la espada sin escalar tiene el tamaño de una unidad y el centro del circulo
            // en el centro del sprite
            Collider2D[] objects = Physics2D.OverlapCircleAll(_swordPosition.position, _swordPosition.localScale.x / 2);

            foreach (Collider2D enemy in objects)
            {
                if (enemy.tag == "Enemy")
                {
                    enemy.GetComponent<Entity.AEntity>().TakeDamage(_attackDamage);
                }
            }
        }

        public override void Dead()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Notify()
        {
            Dead();
        }
    }
}

