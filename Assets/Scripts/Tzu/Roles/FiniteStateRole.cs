using System.Collections.Generic;
using UnityEngine;
//============================================================
//@author	JiphuTzu
//@create	11/24/2017
//@company	Tzu
//
//@description:
//============================================================
namespace Tzu.Roles
{
    public abstract class FiniteStateRole<T> : MonoBehaviour
    {
        private Dictionary<T, State<T>> _states;
        public State<T> currentState { get; private set; }
        public State<T> lastState { get; private set; }
        public void AddState(State<T> state)
        {
            _states.Add(state.id, state);
        }
        public State<T> GetState(T id)
        {
            return _states[id];
        }
        public void SetState(T id)
        {
            State<T> state = GetState(id);
            if (state == null) Debug.LogWarning("You should not set a state not exist");
            lastState = currentState;
            lastState?.Exit();
            currentState = state;
            currentState.Enter();
        }
        public void Init(T id)
        {
            if (currentState != null)
            {
                Debug.LogError("FiniteStateMachine can init only once");
            }
            else
            {
                State<T> state = GetState(id);
                if (state == null) Debug.LogWarning("You should not init a state not exist  " + id);
                currentState = state;
                currentState.Enter();
            }
        }
        protected virtual void Start()
        {
            _states = new Dictionary<T, State<T>>();
        }
        protected virtual void Update()
        {
            currentState?.Update();
        }
        // protected void FixedUpdate()
        // {
        // }
        // protected void LateUpdate()
        // {
        // }
    }
    public abstract class State<T>
    {
        private FiniteStateRole<T> _fsr;
        public T id { get; private set; }
        public State(T id, FiniteStateRole<T> fsr)
        {
            this.id = id;
            this._fsr = fsr;
        }
        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();
        public void GoToState(T id)
        {
            //Debug.Log(owner+".GoTo " + id);
            _fsr.SetState(id);
        }
        public override string ToString()
        {
            return string.Format("State[{0}]",id);
        }
    }
    // public class ComplexState<T, F, S> : State<T, F> where T : MonoBehaviour
    // {
    //     private FiniteStateMachine<T, S> _sfsm;
    //     public ComplexState(F id) : base(id) { }
    //     public override void Init(T owner, FiniteStateMachine<T, F> fsm)
    //     {
    //         base.Init(owner, fsm);
    //         _sfsm = new FiniteStateMachine<T, S>(owner);
    //         Init();
    //     }
    //     protected virtual void Init() { }

    //     public override void Enter() { }

    //     public override void Exit() { }

    //     public override void Update()
    //     {
    //         _sfsm.Update();
    //     }
    //     protected void AddSubState(State<T, S> state)
    //     {
    //         _sfsm.AddState(state);
    //     }
    //     protected void GoToSubState(S id)
    //     {
    //         //Debug.Log("GoToSubState " + id);
    //         _sfsm.SetState(id);
    //     }
    //     protected void Init(S id)
    //     {
    //         _sfsm.Init(id);
    //     }
    // }
}