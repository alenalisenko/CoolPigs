using System.Collections;
using System.Collections.Generic;
using Drone.Commands;
using UnityEngine;
using Drones.Commands;

namespace Drone
{
    public class DroneControl : MonoBehaviour
    {
        public List<ICommand> commandQueue = new List<ICommand>();
        private Coroutine currentExecution;

        public void AddCommand(ICommand command)
        {
            commandQueue.Add(command);
        }

        public void ExecuteCommands()
        {
            if (currentExecution != null)
            {
                StopCoroutine(currentExecution);
            }

            currentExecution = StartCoroutine(ExecuteCommandsCoroutine());
        }

        private IEnumerator ExecuteCommandsCoroutine()
        {
            foreach (var command in commandQueue)
            {
                yield return StartCoroutine(command.Execute());
            }
            
        }
    }
}