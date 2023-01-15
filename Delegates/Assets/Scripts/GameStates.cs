using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace mehmetcanari.CodeVault
{
    public class GameStates : Singleton<GameStates>
    {
        public States _state;
        public UnityEvent _stateCalling;

        private void Update()
        {
            switch (_state == States.Play)
            {
                default:
                    RegisterState();
                    break;
            }
        }

        public void ChangeState(int _stateIndex)
        {
            switch (_stateIndex)
            {
                case 0:
                    _state = States.Finish;
                    break;

                case 1:
                    _state = States.Play;
                    break;
            }
        }

        private void RegisterState()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _stateCalling.Invoke();
            }
        }
    }

    public enum States
    {
        Play,
        Finish
    }
}
