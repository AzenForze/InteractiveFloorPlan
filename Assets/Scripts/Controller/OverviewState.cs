using System;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    class OverviewState : IState
    {
        private FlyingState context;

        private IState substate;

        //states
        public WallState wallState;
        public OverviewMenuState menuState;

        //private
        private GameObject flyingObject;
        private Camera flyCamera;
        private CreateWalls createWallsScript;

        public OverviewState(FlyingState context, GameObject flyingObject, GameObject hud)
        {
            this.context = context;
            this.flyingObject = flyingObject;
            this.flyCamera = flyingObject.GetComponent<Freelook>().flyCamera;
            this.createWallsScript = flyingObject.GetComponent<CreateWalls>();

            this.wallState = new WallState(this, createWallsScript);
            this.menuState = new OverviewMenuState(this, hud);

            // Initial state
            this.substate = this.wallState;
        }

        void IState.Enter()
        {
            this.substate = this.wallState;
            this.substate.Enter();

            var transform = flyingObject.transform;

            transform.localRotation = Quaternion.AngleAxis(transform.localEulerAngles.y, Vector3.up);
            transform.localRotation *= Quaternion.AngleAxis(0, Vector3.left);

            flyCamera.transform.localRotation = Quaternion.AngleAxis(-90, Vector3.left);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            createWallsScript.enabled = true;
        }

        void IState.Exit()
        {
            this.substate.Exit();
            flyCamera.transform.localRotation = Quaternion.AngleAxis(0, Vector3.left);
            Cursor.lockState = CursorLockMode.Locked;
            createWallsScript.enabled = false;
        }

        void IState.Update()
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                context.ChangeState(context.freecamState);
                return;
            }

            this.substate.Update();
        }

        public void ChangeState(IState newState)
        {
            this.substate.Exit();
            this.substate = newState;
            this.substate.Enter();
        }
    }
}
