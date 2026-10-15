using CommandPattern.Classes.Commands;
using CommandPattern.Interfaces;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Classes
{
    internal class RemoteControl
    {
        Command[] onCommands = new Command[7];
        Command[] offCommands = new Command[7];

        Stack<Command> undoCommands = new Stack<Command>();

        public RemoteControl()
        {
            Command noCommand = new NoCommand();
            for (int i = 0; i < onCommands.Length; i++)
            {
                onCommands[i] = noCommand;
                offCommands[i] = noCommand;
            }
        }

        public void SetCommand(int slot, Command onCommand, Command offCommand)
        {
            onCommands[slot] = onCommand;
            offCommands[slot] = offCommand;
        }

        public void OnButtonWasPushed(int slot)
        {
            onCommands[slot].Execute();
            undoCommands.Push(onCommands[slot]); 
        }

        public void OffButtonWasPushed(int slot)
        {
            offCommands[slot].Execute();
            undoCommands.Push(offCommands[slot]); 
        }

        public void UndoButtonWasPushed()
        {
            if (undoCommands.Count > 0)
            {
                Command commandToUndo = undoCommands.Pop();
                commandToUndo.Undo();
            }
            else
            {
                Console.WriteLine("--- Nothing to undo! ---");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n----- Remote Control ----- \n");
            for (int i = 0; i < onCommands.Length; i++)
            {
                sb.Append("[slot " + i + "] " + onCommands[i] + " \t\t  " + offCommands[i] + "\n");
            }
            return sb.ToString();
        }
    }
}