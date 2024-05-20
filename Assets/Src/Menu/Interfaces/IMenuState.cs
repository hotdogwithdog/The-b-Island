using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menu.Interfaces
{
    public interface IMenuState
    {
        void Enter();

        void Update();

        void Exit();
    }
}
