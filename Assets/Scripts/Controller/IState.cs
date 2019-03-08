
namespace Assets.Scripts.Controller
{
    public interface IState
    {
        void Enter();
        void Exit();
        void Update();
    }
}
