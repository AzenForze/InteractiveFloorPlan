
using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.Controller
{
    public interface IState
    {
        void Enter();
        void Exit();
        void Update();
    }

    public class InvalidStateException : Exception
    {
        public InvalidStateException(IState invalidState)
            : base($"Tried to enter invalid state {invalidState}")
        { }
    }
}
