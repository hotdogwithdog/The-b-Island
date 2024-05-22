using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Command.Receivers
{
    public class Player : MonoBehaviour, Interfaces.IMoveableReceiver
    {
        [SerializeField] private float _speed;
        private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            _rigidbody2D = this.GetComponent<Rigidbody2D>();
        }


        public void Move(Vector2 direction)
        {
            _rigidbody2D.AddForce(direction * _speed);
        }
    }
}

