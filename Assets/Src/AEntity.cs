using UnityEngine;

namespace Entity
{
    public abstract class AEntity : MonoBehaviour
    {
        [SerializeField] protected float _hp = 100.0f;
        [SerializeField] protected float _attackDamage = 25.0f;
        [SerializeField] protected float _maxHp = 100.0f;


        public void TakeDamage(float damageTaken)
        {
            _hp -= Mathf.Abs(damageTaken);

            if (_hp <= 0) Dead();
        }

        public void Heal(float healAmount)
        {
            _hp += healAmount;

            if (_hp > _maxHp) _hp = _maxHp;
        }


        public abstract void Dead();
    }
}
