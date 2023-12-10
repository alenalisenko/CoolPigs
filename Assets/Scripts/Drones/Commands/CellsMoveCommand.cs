using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Drone.Commands;

namespace Drones.Commands
{
    public class CellsMoveCommand : MonoBehaviour, ICommand
    {
        public GameObject Drone { get; set; }
        public Vector3 MoveDirection { get; private set; }
        public int CellsCount { get; private set; }
        private float Speed { get; set; } = 2;
        public GameObject cellsMoveCommandSettings { get; set; }

        public void ShowSettingsWindow()
        {
            // Instantiate a settings window prefab or UI elements
            // For simplicity, I'll assume you have a Canvas named "SettingsCanvas" in your scene
            GameObject settingsWindow = Instantiate(cellsMoveCommandSettings);
            
            // Assuming you have UI input fields for direction and cell count in the settings window
            TMP_Dropdown directionDropdown = settingsWindow.GetComponentInChildren<TMP_Dropdown>();
            TMP_InputField cellsCountInput = settingsWindow.GetComponentInChildren<TMP_InputField>();

            // Set up a button click event to apply settings
            Button applyButton = settingsWindow.GetComponentInChildren<Button>();
            applyButton.onClick.AddListener(() => ApplySettings(directionDropdown, cellsCountInput));
        }

        public void ApplySettings(TMP_Dropdown directionDropdown, TMP_InputField cellsCountInput)
        {
            // Parse direction and cells count from UI input
            ParseDirection(directionDropdown);
            ParseCellsCount(cellsCountInput);

            // Close the settings window or handle as needed
            // For simplicity, I'll just destroy it
            Destroy(directionDropdown.transform.parent.gameObject);
        }

        public void ParseDirection(TMP_Dropdown directionDropdown)
        {
            // For simplicity, I assume that the dropdown values are "Up," "Down," "Forward," "Backward"
            switch (directionDropdown.value)
            {
                case 0:
                    MoveDirection = Vector3.up;
                    break;
                case 1:
                    MoveDirection = Vector3.down;
                    break;
                case 2:
                    MoveDirection = Vector3.forward;
                    break;
                case 3:
                    MoveDirection = Vector3.back;
                    break;
                default:
                    MoveDirection = Vector3.up; // Default to up if an invalid value is selected
                    break;
            }
        }

        private void ParseCellsCount(TMP_InputField cellsCountInput)
        {
            if (int.TryParse(cellsCountInput.text, out int parsedCellsCount))
            {
                CellsCount = parsedCellsCount;
            }
            else
            {
                Debug.LogError("Failed to parse CellsCount. Please enter a valid integer.");
            }
        }

        public IEnumerator Execute()
        {
            Drone.GetComponent<DroneStats>().isaction = true;
            Transform _transform = Drone.GetComponent<Transform>();
            Vector3 startPosition = _transform.position;
            _transform.rotation = Quaternion.Euler(0, MoveDirection.x * 180, 0);

            while (_transform.position.x <= startPosition.x + MoveDirection.x * CellsCount || _transform.position.y <= startPosition.y + MoveDirection.y * CellsCount)
            {
                _transform.position += MoveDirection * Speed * Time.deltaTime;
                yield return new WaitForSeconds(Time.deltaTime);
            }

            Drone.GetComponent<DroneStats>().isaction = false;
        }
    }
}
