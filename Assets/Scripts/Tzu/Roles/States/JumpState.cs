using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tzu.Roles.States
{
    public class JumpState : ActionState
    {
        public JumpState(ActionRole owner) : base(ActionID.Jump,owner) { }
    }
}