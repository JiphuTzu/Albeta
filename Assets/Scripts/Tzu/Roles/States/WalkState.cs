using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tzu.Roles.States
{
    public class WalkState : ActionState
    {
        public WalkState(ActionRole owner) : base(ActionID.Walk, owner) { }
    }
}