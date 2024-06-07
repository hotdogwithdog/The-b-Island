using UnityEngine;
using System.Collections.Generic;
using Command.Receivers;
using Command.Commands.Movement;
using Observer.Observers;

namespace Command.Clients
{
    

    public class EnemiesController : MonoBehaviour, IObserver_void_Enemy
    {
        private struct EnemyInfo
        {
            public Enemy enemy;
            public Transform positionLeft;
            public Transform positionRight;

            public EnemyInfo(Enemy enemy, Transform posLeft, Transform posRight)
            {
                this.enemy = enemy;
                this.positionLeft = posLeft;
                this.positionRight = posRight;
            }
        }

        #region Command pattern

        private List<EnemyInfo> _enemiesInfo;   // Receivers de este cliente
        private Invoker.CommandManager _enemiesCommandManager; // Invoker de todos ellos al mismo tiempo

        #endregion



        private void Start()
        {
            _enemiesInfo = new List<EnemyInfo>();
            _enemiesCommandManager = new Invoker.CommandManager();

            GameObject enemiesContainer = GameObject.Find("Enemies");

            foreach (Enemy enemy in enemiesContainer.GetComponentsInChildren<Enemy>())
            {
                enemy.Subscribe(this);  // me suscribo para cuando el enemigo es derrotado destruir el objeto
                _enemiesInfo.Add(new EnemyInfo(enemy, enemy.positionLeft, enemy.positionRight));
            }
        }


        private void Update()
        {
            foreach (EnemyInfo enemyInfo in _enemiesInfo)
            {
                Debug.Log(enemyInfo.positionLeft);
                Debug.Log(enemyInfo.positionRight);

                if (enemyInfo.enemy.transform.position.x < enemyInfo.positionLeft.position.x) enemyInfo.enemy.IsGoingToPointLeft = false;
                else if (enemyInfo.enemy.transform.position.x > enemyInfo.positionRight.position.x) enemyInfo.enemy.IsGoingToPointLeft = true; ;

                if (enemyInfo.enemy.IsGoingToPointLeft)
                {
                    _enemiesCommandManager.ExecuteCommand(new MoveLeft(enemyInfo.enemy));
                }
                else
                {
                    _enemiesCommandManager.ExecuteCommand(new MoveRight(enemyInfo.enemy));
                }
            }
        }

        public void Notify(Enemy enemy)
        {
            // Necesitamos hacer el bucle porque tenemos una lista de EnemyInfo no de Enemy, de todas maneras así nos aseguramos de que no queda ninguno, dentro de la lista
            for (int i = 0; i < _enemiesInfo.Count; i++)
            {
                if (_enemiesInfo[i].enemy == enemy) _enemiesInfo.Remove(_enemiesInfo[i]);
            }
        }
    }
}
