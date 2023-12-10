namespace Drones
{
    using UnityEngine;

    public class DroneStats : MonoBehaviour
    {
        // Свойства статистики дрона
        public float maxCharge = 100f;
        public float energy { get; set; }
        public bool isaction { get; set; }

        // Дополнительные свойства и методы по мере необходимости
        // ...

        private void Start()
        {
            // Инициализация начальных значений
            energy = maxCharge;
            isaction = false;
        }

        // Другие методы и свойства по мере необходимости
        // ...
    }

}