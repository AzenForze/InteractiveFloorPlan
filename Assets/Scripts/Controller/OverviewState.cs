using System;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    class OverviewState : IState
    {
        private Freelook context;
        private Camera flyCamera;
        private CreateWalls createWallsScript;

        public OverviewState(Freelook context, Camera flyCamera, CreateWalls createWallsScript)
        {
            this.context = context;
            this.flyCamera = flyCamera;
            this.createWallsScript = createWallsScript;
        }

        void IState.Enter()
        {
            var transform = context.transform;

            transform.localRotation = Quaternion.AngleAxis(transform.localEulerAngles.y, Vector3.up);
            transform.localRotation *= Quaternion.AngleAxis(0, Vector3.left);

            flyCamera.transform.localRotation = Quaternion.AngleAxis(-90, Vector3.left);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            createWallsScript.enabled = true;
        }

        void IState.Exit()
        {
            flyCamera.transform.localRotation = Quaternion.AngleAxis(0, Vector3.left);
            Cursor.lockState = CursorLockMode.Locked;
            createWallsScript.enabled = false;
        }

        void IState.Update()
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                context.ChangeState(context.freecamState);
            }
        }
    }
}
