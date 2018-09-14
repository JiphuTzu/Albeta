using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tzu.Brains
{
    //输出指令，影响角色状态的变化
    public class Brain : MonoBehaviour
    {
        private Dictionary<Instruction, Action> _instructions;
        private Dictionary<Instruction, Action> _instructionEnters;
        private Dictionary<Instruction, Action> _instructionExits;

        public void AddInstruction(Instruction key, Action callback)
        {
            if (_instructions == null)
            {
                _instructions = new Dictionary<Instruction, Action>();
                _instructions.Add(key, callback);
            }
            else if (_instructions.ContainsKey(key))
            {
                Action callbacks = _instructions[key];
                callbacks += callback;
                _instructions[key] = callbacks;
            }
            else
            {
                _instructions.Add(key, callback);
            }
        }
        public void AddInstructionEnter(Instruction key, Action callback)
        {
            if (_instructionEnters == null)
            {
                _instructionEnters = new Dictionary<Instruction, Action>();
                _instructionEnters.Add(key, callback);
            }
            else if (_instructionEnters.ContainsKey(key))
            {
                Action callbacks = _instructionEnters[key];
                callbacks += callback;
                _instructionEnters[key] = callbacks;
            }
            else
            {
                _instructionEnters.Add(key, callback);
            }
        }
        public void AddInstructionExit(Instruction key, Action callback)
        {
            if (_instructionExits == null)
            {
                _instructionExits = new Dictionary<Instruction, Action>();
                _instructionExits.Add(key, callback);
            }
            else if (_instructionExits.ContainsKey(key))
            {
                Action callbacks = _instructionExits[key];
                callbacks += callback;
                _instructionExits[key] = callback;
            }
            else
            {
                _instructionExits.Add(key, callback);
            }
        }
        public void RemoveInstruction(Instruction key, Action callback)
        {
            if (_instructions == null || !_instructions.ContainsKey(key)) return;
            Action callbacks = _instructions[key];
            callbacks -= callback;
            if (callbacks == null) _instructions.Remove(key);
            else _instructions[key] = callbacks;
        }
        public void RemoveInstructionEnter(Instruction key, Action callback)
        {
            if (_instructionEnters == null || !_instructionEnters.ContainsKey(key)) return;
            Action callbacks = _instructionEnters[key];
            callbacks -= callback;
            if (callbacks == null) _instructionEnters.Remove(key);
            else _instructionEnters[key] = callbacks;
        }
        public void RemovenstructionExit(Instruction key, Action callback)
        {
            if (_instructionExits == null || !_instructionExits.ContainsKey(key)) return;
            Action callbacks = _instructionExits[key];
            callbacks -= callback;
            if (callbacks == null) _instructionExits.Remove(key);
            else _instructionExits[key] = callbacks;
        }
        protected void Invoke(Instruction key)
        {
            if (_instructions == null || !_instructions.ContainsKey(key)) return;
            _instructions[key].Invoke();
        }
        protected void InvokeEnter(Instruction key)
        {
            if (_instructionEnters == null || !_instructionEnters.ContainsKey(key)) return;
            _instructionEnters[key].Invoke();
        }
        protected void InvokeExit(Instruction key)
        {
            if (_instructionExits == null || !_instructionExits.ContainsKey(key)) return;
            _instructionExits[key].Invoke();
        }
    }
    public enum Instruction
    {
        Jump,
        Punch,
        Kick,
        Left,
        Right,
        Up,
        Down
    }
}
