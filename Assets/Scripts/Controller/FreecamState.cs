using UnityEngine;

namespace Assets.Scripts.Controller
{
    // Mostly handles mouselook. And transitions to Overview state.
    class FreecamState : IState
    {
        private Freelook context;

        float rotationX = 0f;
        float rotationY = 0f;

        public FreecamState(Freelook context)
        {
            this.context = context;
        }

        public void Enter() { }

        public void Exit() { }

        public void Update()
        {
            if( Input.GetKeyDown(KeyCode.T))
            {
                context.ChangeState(context.overviewState);
            }

            // instead of going from 0 to 360 cw, go from -180 to 180 ccw, keeping 0 the same
            var direction = 540 - context.transform.localEulerAngles.x; // (360 - x) + 180 = 540 - x
            direction %= 360;
            direction -= 180;

            rotationX = context.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * context.XSensitivity;
            rotationX = ((rotationX + 180) % 360) - 180;
            rotationY = direction + Input.GetAxis("Mouse Y") * context.YSensitivity;
            rotationY = Mathf.Clamp(rotationY, -90, 90);

            context.transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
            context.transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);
        }
    }
}
