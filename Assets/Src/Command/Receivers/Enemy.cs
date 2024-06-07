using UnityEngine;
using Observer.Subjects;
using Observer.Observers;
using System.Collections.Generic;

namespace Command.Receivers
{
    public class Enemy : Entity.AEntity, Interfaces.IMoveableReceiver, ISubject_void_Enemy
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

        private List<IObserver_void_Enemy> _observers = new List<IObserver_void_Enemy>();


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
            _inputDirection = direction;
        }

        public override void Dead()
        {
            // Lo primero es acceder al enemies controller para sacar este objeto de la lista de enemigos, lo vamos a hacer con un patron observador
            Invoke();

            // destruyo los objetos es el enemigo, y no tiene animación de muerte así que simplemente se libera la memoria de este, destruyendo tambien
            // los puntos que controlan el movimiento
            Destroy(positionLeft.gameObject);
            Destroy(positionRight.gameObject);

            Destroy(this.gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<Entity.AEntity>().TakeDamage(_attackDamage);
            }
        }

        public void Invoke()
        {
            foreach (IObserver_void_Enemy observer in _observers)
            {
                observer.Notify(this);
            }
        }

        public void Subscribe(IObserver_void_Enemy observer)
        {
            _observers.Add(observer);
        }

        public void Unsuscribe(IObserver_void_Enemy observer)
        {
            _observers.Remove(observer);
        }
    }
}
