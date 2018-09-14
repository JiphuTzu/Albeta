using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tzu.Brains
{
    public class PlayerBrain : Brain
    {
        private Dictionary<KeyCode, Instruction> _keys = new Dictionary<KeyCode, Instruction>()
        {
            {KeyCode.Space, Instruction.Jump},
            {KeyCode.Z, Instruction.Punch},
            {KeyCode.X, Instruction.Kick},
            {KeyCode.LeftArrow, Instruction.Left},
            {KeyCode.RightArrow, Instruction.Right},
            {KeyCode.UpArrow, Instruction.Up},
            {KeyCode.DownArrow, Instruction.Down}
        };
        //获取键盘状态
        private void Update()
        {
            foreach (var item in _keys)
            {
                if (Input.GetKeyDown(item.Key))
                {
                    InvokeEnter(item.Value);
                    break;
                }
                else if (Input.GetKeyUp(item.Key))
                {
                    InvokeExit(item.Value);
                    break;
                }
            }
        }
    }
}