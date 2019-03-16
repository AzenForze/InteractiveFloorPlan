using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections.Generic;

namespace Assets.Scripts.Controller
{
    class WalkingState : IState
    {
        // Current substate
        private IState substate;

        // possible substates
        public WalkingMenuState menuSubstate { get; private set; }
        public WalkingNormalState normalSubstate { get; private set; }

        private RigidbodyFirstPersonController controller;
        private Camera camera;

        private AgentController context;
        private GameObject hud;

        public WalkingState(AgentController context, RigidbodyFirstPersonController FPController, Camera FPCamera, GameObject hud)
        {
            this.context = context;
            controller = FPController;
            camera = FPCamera;
            this.menuSubstate = new WalkingMenuState(this, hud);
            this.normalSubstate = new WalkingNormalState(this, controller);
        }

        public void Enter()
        {
            // Set up FPPController
            this.substate = normalSubstate;
            this.substate.Enter();
            controller.enabled = true;
            camera.enabled = true;
        }

        public void Exit()
        {
            // Clean up FPPController
            this.substate.Exit();
            controller.enabled = false;
            camera.enabled = false;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                context.ChangeState( context.FlyingState );
            }

            this.substate.Update();
        }

        public void ChangeState(IState newState)
        {
            // newstate should always be one of the substates initialized in this class
            if(newState != normalSubstate && newState != menuSubstate)
            {
                throw new InvalidStateException(newState);
            }

            this.substate.Exit();
            this.substate = newState;
            this.substate.Enter();
        }
    }
}
