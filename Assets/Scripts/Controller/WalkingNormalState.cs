using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Assets.Scripts.Controller
{
    class WalkingNormalState : IState
    {
        private WalkingState context;
        private RigidbodyFirstPersonController controller;

        public WalkingNormalState(WalkingState context, RigidbodyFirstPersonController controller)
        {
            this.context = context;
            this.controller = controller;
        }

        void IState.Enter()
        {
            Cursor.lockState = CursorLockMode.Locked;
            controller.enabled = true;
        }

        void IState.Exit()
        {
            controller.enabled = false;
        }

        void IState.Update()
        {
            if(Input.GetKeyDown(KeyCode.M))
            {
                Debug.Log("Pressed M");
                context.ChangeState(context.menuSubstate);
            }
        }
    }
}
