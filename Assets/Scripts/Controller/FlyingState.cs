using UnityEngine;

namespace Assets.Scripts.Controller
{
    class FlyingState : IState
    {
        private AgentController context;

        private IState substate;

        // possible substates (initialized once)
        public FreecamState freecamState;
        public OverviewState overviewState;

        private GameObject flyingCamera;
        private Transform resetTransform;

        public FlyingState(AgentController context, GameObject flyingCamera, Transform resetTransform, GameObject hud)
        {
            this.context = context;
            this.flyingCamera = flyingCamera;
            this.resetTransform = resetTransform;
            freecamState = new FreecamState(this, flyingCamera);
            overviewState = new OverviewState(this, flyingCamera, hud);

            this.substate = freecamState;
        }

        public void Enter()
        {
            this.substate = this.freecamState;
            this.substate.Enter();

            flyingCamera.SetActive(true);
            flyingCamera.transform.position = resetTransform.position;
            flyingCamera.transform.rotation = resetTransform.rotation;
        }

        public void Exit()
        {
            this.substate.Exit();

            flyingCamera.SetActive(false);
        }

        public void ChangeState(IState newState)
        {
            this.substate.Exit();
            this.substate = newState;
            this.substate.Enter();
        }

        public void Update()
        {
            this.substate.Update();

            if(Input.GetKeyDown(KeyCode.C))
            {
                context.ChangeState(context.WalkingState);
            }
        }
    }
}
