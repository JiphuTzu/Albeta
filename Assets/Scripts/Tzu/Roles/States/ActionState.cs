using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tzu.Brains;
using Tzu.Roles;

namespace Tzu.Roles.States
{
    public class ActionState : State<ActionID>
    {
        protected ActionRole role;
        public ActionState(ActionID id, ActionRole owner) : base(id, owner)
        {
            role = owner;
        }
        protected void Jump()
        {
            GoToState(ActionID.Jump);
        }
        protected void Idle()
        {
            GoToState(ActionID.Idle);
        }
        protected void Run()
        {
            GoToState(ActionID.Run);
        }
        protected void Walk()
        {
            GoToState(ActionID.Walk);
        }

        public override void Enter() { }
        public override void Exit() { }
        public override void Update() { }
        protected void AddInstruction(Instruction key, Action callback)
        {
            role.brain.AddInstruction(key, callback);
        }
        protected void AddInstructionEnter(Instruction key, Action callback)
        {
            role.brain.AddInstructionEnter(key, callback);
        }
        protected void AddInstructionExit(Instruction key, Action callback)
        {
            role.brain.AddInstructionExit(key, callback);
        }
        protected void RemoveInstruction(Instruction key, Action callback)
        {
            role.brain.RemoveInstruction(key, callback);
        }
        protected void RemoveInstructionEnter(Instruction key, Action callback)
        {
            role.brain.RemoveInstructionEnter(key, callback);
        }
        protected void RemoveInstructionExit(Instruction key, Action callback)
        {
            role.brain.RemovenstructionExit(key, callback);
        }
    }
}