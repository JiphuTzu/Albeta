using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tzu.Roles.States;
namespace Tzu.Roles
{
    public class ActionRole : FiniteStateRole<ActionID>
    {
        protected override void Start()
        {
            base.Start();
            AddState(new IdleState(this));
            AddState(new WalkState(this));
            AddState(new RunState(this));
            AddState(new JumpState(this));
        }
    }
}