using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tzu.Roles;
namespace Tzu.Roles.States
{
    public class ActionState : State<ActionID>
    {
        public ActionState(ActionID id, ActionRole owner) : base(id, owner) { }

        public override void Enter() { 
        }
        public override void Exit() { }
        public override void Update() { }
    }
}