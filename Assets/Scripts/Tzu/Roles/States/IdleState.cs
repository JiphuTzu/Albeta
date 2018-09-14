using System.Collections;
using System.Collections.Generic;
using Tzu.Brains;
using UnityEngine;
namespace Tzu.Roles.States
{
    public class IdleState : ActionState
    {
        public IdleState(ActionRole owner) : base(ActionID.Idle, owner) { }
        public override void Enter()
        {
            role.Play("idle");
            //待机状态，可以接受所有动作
            AddInstructionEnter(Instruction.Jump, Jump);
        }
        public override void Exit()
        {
            RemoveInstructionEnter(Instruction.Jump, Jump);
        }
    }
}