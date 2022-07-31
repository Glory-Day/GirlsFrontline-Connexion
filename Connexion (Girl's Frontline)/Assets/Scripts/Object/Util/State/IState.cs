﻿namespace Object.Util.State
{
    public interface IState
    {
        void Enter();
        void Update();
        void Exit();
    }
}