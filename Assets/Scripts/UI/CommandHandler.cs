using System.Collections.Generic;
using System.Linq;
using Drone;
using Drone.Commands;
using Drones.Commands;
using UnityEngine;
using TMPro;
using UnityEngine.UI; // Не забудьте добавить эту директиву

namespace UI
{


    public class CommandHandler : MonoBehaviour
    {
        public TMP_Dropdown dropdown;
        public Transform commandPanel; // Панель, на которой будут отображаться команды
        public List<ICommand> commandPool = new List<ICommand>();
        public TextMeshProUGUI referenceText; // Ссылка на объект TextMeshProUGUI для определения высоты
        public Button addButton; // Ссылка на объект Button для добавления команды
        public Button startButton;
        public float distanceBetweenCommands = 5f; // Расстояние между командами
        public List<GameObject> settingsWindows;
        private DroneControl droneController;
        // Словарь для хранения объектов ICommand по имени
        public Dictionary<string, ICommand> commandDictionary = new Dictionary<string, ICommand>()
        {
            { "Двигаться вперед на", new CellsMoveCommand() },
            { "Двигаться до столкновения", new CellsMoveUntilHitCommand() },
        };

        public void PutSettingsWindows()
        {
            commandDictionary["Двигаться вперед на"].cellsMoveCommandSettings = settingsWindows[0];
        }

        private void Start()
        {
            PutSettingsWindows();
            // Сделаем объект referenceText невидимым
            referenceText.gameObject.SetActive(false);

            // Создадим опции TMP_Dropdown из списка команд
            List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
            foreach (string commandName in commandDictionary.Keys)
            {
                options.Add(new TMP_Dropdown.OptionData(commandName));
            }

            // Добавим опции в TMP_Dropdown
            dropdown.AddOptions(options);
            droneController = GetComponent<DroneControl>();
            // Подпишемся на событие нажатия кнопки
            addButton.onClick.AddListener(OnAddButtonClick);
            startButton.onClick.AddListener(OnStartButtonClick);
        }

        private void OnAddButtonClick()
        {
            // Получим имя выбранной команды из словаря
            string selectedCommandName = dropdown.options[dropdown.value].text;

            // Получим объект ICommand по имени
            ICommand selectedCommand = commandDictionary[selectedCommandName];
            selectedCommand.ShowSettingsWindow();

            // Добавим выбранную команду в массив commandObjects
            if (commandPool.Count <= 13)
            {
                commandPool.Add(selectedCommand);
            }
            else
            {
                return;
            }

            // Создадим текстовый объект на панели команд
            GameObject textObject = new GameObject();
            textObject.transform.SetParent(commandPanel);
            TextMeshProUGUI textComponent = textObject.AddComponent<TextMeshProUGUI>();
            textComponent.text = commandPool.Count + ". " + selectedCommandName;

            // Устанавливаем размер шрифта текста
            textComponent.fontSize = referenceText.fontSize;

            // Устанавливаем цвет текста
            textComponent.color = Color.black;

            // Обновляем положение текста
            RectTransform textRectTransform = textComponent.rectTransform;
            if (commandPool.Count == 1)
            {
                // Если это первая команда, разместите ее в том же месте, что и объект referenceText
                textRectTransform.anchoredPosition = referenceText.rectTransform.anchoredPosition;

            }
            else if (commandPool.Count < 8)
            {
                // Если это не первая команда, разместите ее ниже предыдущей с учетом расстояния между командами
                TextMeshProUGUI prevText =
                    commandPanel.GetChild(commandPanel.childCount - 2).GetComponent<TextMeshProUGUI>();
                textRectTransform.anchoredPosition = new Vector2(prevText.rectTransform.anchoredPosition.x,
                    prevText.rectTransform.anchoredPosition.y - prevText.rectTransform.sizeDelta.y / 2 -
                    distanceBetweenCommands);
            }
            else if (commandPool.Count == 8)
            {
                TextMeshProUGUI prevText =
                    commandPanel.GetChild(commandPanel.childCount - 2).GetComponent<TextMeshProUGUI>();
                textRectTransform.anchoredPosition = new Vector2(prevText.rectTransform.anchoredPosition.x + 300f,
                    prevText.rectTransform.anchoredPosition.y +
                    (prevText.rectTransform.sizeDelta.y / 2 + distanceBetweenCommands) * 6);
            }
            else if (commandPool.Count < 15)
            {
                TextMeshProUGUI prevText =
                    commandPanel.GetChild(commandPanel.childCount - 2).GetComponent<TextMeshProUGUI>();
                textRectTransform.anchoredPosition = new Vector2(prevText.rectTransform.anchoredPosition.x,
                    prevText.rectTransform.anchoredPosition.y - prevText.rectTransform.sizeDelta.y / 2 -
                    distanceBetweenCommands);
            }
            droneController.AddCommand(selectedCommand);
        }
        private void OnStartButtonClick()
        {
            // Проверим, что DroneController существует
            if (droneController != null)
            {
                // Вызываем выполнение команд
                droneController.ExecuteCommands();
            }
            else
            {
                Debug.LogError("DroneController not found. Make sure it is attached to the same GameObject as CommandHandler.");
            }
        }
    }
}