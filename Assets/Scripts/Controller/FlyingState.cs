using UnityEngine;

namespace Assets.Scripts.Controller
{
    class FlyingState : IState
    {
        private AgentController context;

        private GameObject flyingCameraPrefab;
        private GameObject flyingCamera;
        private Transform resetTransform;

        public FlyingState(AgentController context, GameObject flyingCameraPrefab, Transform resetTransform)
        {
            this.context = context;
            this.flyingCameraPrefab = flyingCameraPrefab;
            this.resetTransform = resetTransform;
        }

        public void Enter()
        {
            // The "flyingCamera" GameObject is practically it's own state machine.
            // Its states function as substates of this state.
            flyingCamera = Object.Instantiate(flyingCameraPrefab, resetTransform.position, resetTransform.rotation);
        }

        public void Exit()
        {
            // Clean up Flying Camera GameObject
            Object.Destroy(flyingCamera);
        }

        public void Update()
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                context.ChangeState(context.WalkingState);
            }
        }
    }
}
