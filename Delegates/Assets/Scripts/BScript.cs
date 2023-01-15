using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace mehmetcanari.CodeVault
{
    public class BScript : MonoBehaviour
    {
        public int _scaleTime;
        public Ease _easing;

        public delegate void CubeBehaviour(); //Defining delegate type
        public CubeBehaviour _delegateBehaviour; //Creating object of delegate

        private void Update()
        {
            RegisterInput();
        }

        private void RegisterInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                switch (GameStates.Instance._state)
                {
                    case States.Play:
                        RegisterDelegateVoids();

                        _delegateBehaviour(); //Calling delagate object for action
                        break;
                }
            }
        }

        private void RegisterDelegateVoids() //Adding voids into delegate struct
        {
            _delegateBehaviour += ScaleObject;

        }

        #region Behaviour Methods
        private void ScaleObject()
        {
            transform.DOScale(transform.localScale * 2, _scaleTime).SetEase(_easing);
        }
        #endregion
    }
}

