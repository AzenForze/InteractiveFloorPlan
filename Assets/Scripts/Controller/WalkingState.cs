using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Assets.Scripts.Controller
{
    class WalkingState : IState
    {
        private RigidbodyFirstPersonController controller;
        private Camera camera;

        private AgentController context;

        public WalkingState(AgentController context, RigidbodyFirstPersonController FPController, Camera FPCamera)
        {
            this.context = context;
            controller = FPController;
            camera = FPCamera;
        }

        public void Enter()
        {
            // Set up FPPController
            controller.enabled = true;
            camera.enabled = true;
        }

        public void Exit()
        {
            // Clean up FPPController
            controller.enabled = false;
            camera.enabled = false;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                context.ChangeState( context.FlyingState );
            }
        }
    }
}
