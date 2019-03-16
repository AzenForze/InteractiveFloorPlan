using UnityEngine;

namespace Assets.Scripts.Controller
{
    class OverviewMenuState : IState
    {
        private OverviewState context;
        private GameObject hud;

        public OverviewMenuState(OverviewState context, GameObject hud)
        {
            this.context = context;
            this.hud = hud;
        }

        void IState.Enter()
        {
            hud.SetActive(true);
        }

        void IState.Exit()
        {
            hud.SetActive(false);
        }

        void IState.Update()
        {
            if(Input.GetKeyDown(KeyCode.M))
            {
                context.ChangeState(context.wallState);
            }
        }
    }
}
