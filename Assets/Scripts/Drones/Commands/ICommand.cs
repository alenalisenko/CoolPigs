using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Drones.Commands
{
    public interface ICommand
    {
        void Execute();
        void ShowSettingsWindow();
        public GameObject cellsMoveCommandSettings { get; set; }
        public GameObject Drone { get; set; }
    }
}