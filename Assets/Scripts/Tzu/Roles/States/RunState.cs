using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tzu.Roles.States
{
    public class RunState : ActionState
    {
        public RunState(ActionRole owner) : base(ActionID.Run,owner) { }
    }
}