using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tzu.Roles.States;
using Tzu.Utils;
using Tzu.Brains;

namespace Tzu.Roles
{
    public class ActionRole : FiniteStateRole<ActionID>
    {
        private bool _isGrounded = false;
        private int _isGroundedFrame = 0;
        public bool isGrounded
        {
            get
            {
                if (Time.frameCount != _isGroundedFrame)
                {
                    _isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.01F, Layer.GetMask(Layer.Ground));
                    _isGroundedFrame = Time.frameCount;
                }
                return _isGrounded;
            }
        }
        private Brain _brain;
        public Brain brain
        {
            get
            {
                if (_brain == null) _brain = GetComponent<Brain>();
                return _brain;
            }
        }
        protected override void Start()
        {
            base.Start();
            AddState(new IdleState(this));
            AddState(new WalkState(this));
            AddState(new RunState(this));
            AddState(new JumpState(this));
            //
            Init(ActionID.Idle);
        }
        public void Play(string action)
        {
            Debug.Log("play action : " + action);
        }
    }
}