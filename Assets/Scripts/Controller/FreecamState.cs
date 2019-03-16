using UnityEngine;

namespace Assets.Scripts.Controller
{
    // Mostly handles mouselook. And transitions to Overview state.
    class FreecamState : IState
    {
        private FlyingState context;
        private GameObject flyingObject;

        private Freelook freelookScript;

        public FreecamState(FlyingState context, GameObject flyingObject)
        {
            this.context = context;
            this.flyingObject = flyingObject;
            this.freelookScript = flyingObject.GetComponent<Freelook>();
        }

        public void Enter() { }

        public void Exit() { }

        public void Update()
        {
            if( Input.GetKeyDown(KeyCode.T))
            {
                context.ChangeState(context.overviewState);
            }

            freelookScript.Mouselook();
        }
    }
}
