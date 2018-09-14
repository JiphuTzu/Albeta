using System.Collections;
using System.Collections.Generic;
using Tzu.Brains;
using UnityEngine;
namespace Tzu.Roles.States
{
    public class JumpState : ActionState
    {
        public JumpState(ActionRole owner) : base(ActionID.Jump, owner) { }
        public override void Enter()
        {
            //起跳
            role.Play("jump");
            AddInstructionEnter(Instruction.Jump, Rejump);
            AddInstructionEnter(Instruction.Punch, Punch);
            AddInstructionEnter(Instruction.Kick, Kick);
        }
        public override void Exit()
        {
            RemoveInstructionEnter(Instruction.Jump, Rejump);
            RemoveInstructionEnter(Instruction.Punch, Punch);
            RemoveInstructionEnter(Instruction.Kick, Kick);
        }
        private void Kick()
        {
            //跳踢
            role.Play("kick");
        }
        private void Punch()
        {
            //跳拳
            role.Play("Punch");
        }
        private void Rejump()
        {
            //二次起跳，只能连续跳两次，所以把jump的指令删除
            RemoveInstructionEnter(Instruction.Jump, Rejump);
            //
            role.Play("jump2");
        }
    }
}