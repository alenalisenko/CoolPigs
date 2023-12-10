using System.Collections;
using System.Collections.Generic;
using Drone.Commands;
using UnityEngine;

namespace Drones.Commands
{
    public class CellsMoveUntilHitCommand : ICommand
    {
        public GameObject drone { get; set; }
        public Vector3 moveDirection { get; set; }
        public float speed { get; set; } = 5;
        public GameObject cellsMoveCommandSettings { get; set; }

        public void ShowSettingsWindow()
        {
            
        }

        public IEnumerator Execute()
        {
            drone.GetComponent<DroneStats>().isaction = true;
            Transform _transform = drone.GetComponent<Transform>();
            _transform.rotation = Quaternion.Euler(0, moveDirection.x * 180, 0);

            while (!Physics.Raycast(_transform.position, moveDirection, 1f, 3))
            {
                _transform.position += moveDirection * speed * Time.deltaTime;
                yield return new WaitForSeconds(Time.deltaTime);
            }

            yield return new WaitForSeconds(0.25f);
            drone.GetComponent<DroneStats>().isaction = false;
        }
    }
}