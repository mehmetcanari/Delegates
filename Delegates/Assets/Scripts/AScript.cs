using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.Events;

public class AScript : MonoBehaviour
{
    [Header("Attributes")]
    public float _moveTime;
    public int _yValue;
    public Ease _easing;

    public delegate void CubeBehaviour();
    public CubeBehaviour _delegateBehaviour;

    public UnityEvent _eventCalling;

    private void Update()
    {
        switch (GameStates.Instance._state)
        {
            case States.Play:
                InputRegister();
                break;
        }
    }

    private void InputRegister()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DelegateRegister();

            _delegateBehaviour();

            _eventCalling.Invoke();
        }
    }

    private void DelegateRegister()
    {
        _delegateBehaviour += CubeMovement;
        _delegateBehaviour += MaterialAccessDelay;
    }

    private void CubeMovement()
    {
        this.transform.DOMove(new Vector3(-2, _yValue, 0), _moveTime).SetEase(_easing);
    }

    private void MaterialAccessDelay()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
