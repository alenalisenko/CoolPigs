using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Drone.Commands
{
    public interface ICommand
    {
        IEnumerator Execute();
        void ShowSettingsWindow();
        public GameObject cellsMoveCommandSettings { get; set; }
    }
}