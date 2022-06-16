using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    // Start is called before the first frame update
    public interface ICommand
    {
        void Execute();

    }

    public static CommandManager Instance { get; private set; }

    private Stack<ICommand> m_CommandsBuffer = new Stack<ICommand>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddCommand(ICommand command)
    {
        command.Execute();
        m_CommandsBuffer.Push(command);
    }

    public void RemoveCommand() 
    {
        if(m_CommandsBuffer.Count > 0)
        {
            var command=m_CommandsBuffer.Pop();
            command.Execute();
        }
        else
        {
            Debug.Log("No more commands to go back");
        }
    }
    
}
