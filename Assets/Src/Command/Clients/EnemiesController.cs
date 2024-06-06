using UnityEngine;
using System.Collections.Generic;
using Command.Receivers;
using Command.Commands.Movement;

namespace Command.Clients
{
    public struct EnemyInfo
    {
        public Enemy enemy;
        public Transform positionLeft;
        public Transform positionRight;

        public EnemyInfo(Enemy enemy, Transform pos1, Transform pos2)
        {
            this.enemy = enemy;
            this.positionLeft = pos1;
            this.positionRight = pos2;
        }
    }

    public class EnemiesController : MonoBehaviour
    {
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


    }
}
