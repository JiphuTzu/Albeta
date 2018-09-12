using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tzu.Roles.States
{
    public class IdleState : ActionState
    {
        public IdleState(ActionRole owner) : base(ActionID.Idle,owner) { }
    }
}