using System.Collections;
using UnityEngine;

namespace Drones.Commands
{
    public class CellsMoveUntilHitCommand : ICommand
    {
        public GameObject Drone { get; set; }
        public Vector3 moveDirection { get; set; }
        public float speed { get; set; } = 5;
        public GameObject cellsMoveCommandSettings { get; set; }

        public void ShowSettingsWindow()
        {
            
        }

        public void Execute()
        {
            // Drone.GetComponent<DroneStats>().isaction = true;
            // Transform _transform = Drone.GetComponent<Transform>();
            // _transform.rotation = Quaternion.Euler(0, moveDirection.x * 180, 0);
            //
            // while (!Physics.Raycast(_transform.position, moveDirection, 1f, 3))
            // {
            //     _transform.position += moveDirection * speed * Time.deltaTime;
            //     yield return new WaitForSeconds(Time.deltaTime);
            // }
            //
            // yield return new WaitForSeconds(0.25f);
            // Drone.GetComponent<DroneStats>().isaction = false;
        }
    }
}