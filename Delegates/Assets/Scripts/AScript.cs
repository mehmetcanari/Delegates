using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.Events;

namespace mehmetcanari.CodeVault
{
    public class AScript : MonoBehaviour
    {
        [Header("Attributes")]
        public float _moveTime;
        public int _yValue;
        public Ease _easing;

        public delegate void CubeBehaviour(); //Defining delegate type
        public CubeBehaviour _delegateBehaviour; //Creating object of delegate

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
                RegisterDelegateVoids();

                _delegateBehaviour(); //Calling delagate object for action
            }
        }

        private void RegisterDelegateVoids() //Adding voids into delegate struct
        {
            _delegateBehaviour += CubeMovement;
            _delegateBehaviour += MaterialAccessDelay;
        }

        #region Behaviour Methods
        private void CubeMovement()
        {
            this.transform.DOMove(new Vector3(-2, _yValue, 0), _moveTime).SetEase(_easing);
        }

        private void MaterialAccessDelay()
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        #endregion
    }
}

