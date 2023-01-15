using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStates : Singleton<GameStates>
{
    public States _state;

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
}

public enum States
{
    Play,
    Finish
}
