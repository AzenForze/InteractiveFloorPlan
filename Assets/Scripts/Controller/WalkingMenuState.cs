using UnityEngine;

namespace Assets.Scripts.Controller
{
    class WalkingMenuState : IState
    {
        private WalkingState context;

        private GameObject hud;

        public WalkingMenuState(WalkingState context, GameObject hud)
        {
            this.context = context;
            this.hud = hud;
        }

        void IState.Enter()
        {
            hud.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        void IState.Exit()
        {
            hud.SetActive(false);
        }

        void IState.Update()
        {
            if(Input.GetKeyDown(KeyCode.M))
            {
                context.ChangeState(context.normalSubstate);
            }
        }
    }
}
