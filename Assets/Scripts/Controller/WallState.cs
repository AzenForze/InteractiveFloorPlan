using UnityEngine;

namespace Assets.Scripts.Controller
{
    class WallState : IState
    {
        private OverviewState context;
        private CreateWalls createWallsScript;

        public WallState(OverviewState context, CreateWalls createWallsScript)
        {
            this.context = context;
            this.createWallsScript = createWallsScript;
        }

        void IState.Enter()
        {
            createWallsScript.enabled = true;
        }

        void IState.Exit()
        {
            createWallsScript.enabled = false;
        }

        void IState.Update()
        {
            if(Input.GetKeyDown(KeyCode.M))
            {
                context.ChangeState(context.menuState);
            }
        }
    }
}
