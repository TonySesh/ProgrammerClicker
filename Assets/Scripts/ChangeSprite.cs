using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour
{
    [System.Serializable]
    public class SpriteGroup
    {

        public SpriteRenderer[] sprites; // Массив спрайтов
        private int currentIndex = 0; // Индекс текущего видимого спрайта
        public Button switchButton; // Ссылка на кнопку
        private bool isPurchased = false; // Флаг, указывающий, была ли сделана покупка
        public GameObject messageText; // Ссылка на текстовый элемент
        public void Start()
        {
            // Убедитесь, что все спрайты, кроме первого, невидимы
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i].gameObject.SetActive(i == currentIndex);
            }

            // Убедитесь, что кнопка активна в начале
            switchButton.interactable = true;
            messageText.SetActive(true); // Убедитесь, что текстовый элемент видим в начале
        }

        public void OnButtonPress()
        {
            // Проверяем, если текущий индекс меньше последнего спрайта и покупка еще не сделана
            if (currentIndex < sprites.Length - 1 && !isPurchased)
            {
                // Скрыть текущий спрайт
                sprites[currentIndex].gameObject.SetActive(false);
                // Увеличить индекс
                currentIndex++;
                // Показать следующий спрайт
                sprites[currentIndex].gameObject.SetActive(true);
            }

            // Если мы на последнем спрайте и покупка еще не сделана
            if (currentIndex == sprites.Length - 1 && !isPurchased)
            {
                PurchaseLastSprite(); // Вызываем метод покупки
            }
        }

        private void PurchaseLastSprite()
        {
            // Логика покупки последнего спрайта
            isPurchased = true; // Устанавливаем флаг, что покупка была сделана
            switchButton.interactable = false; // Блокируем кнопку
            messageText.SetActive(false); // Скрываем текстовый элемент
        }

        public void ResetButton()
        {
            // Сбросить состояние кнопки и текущий индекс
            currentIndex = 0;
            isPurchased = false; // Сбрасываем флаг покупки
            switchButton.interactable = true;

            // Вернуть видимость первого спрайта
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i].gameObject.SetActive(i == currentIndex);
            }
        }
    
  
}

    public SpriteGroup[] spriteGroups; // Массив групп спрайтов

    void Start()
    {
        // Инициализируем каждую группу спрайтов
        foreach (var group in spriteGroups)
        {
            group.Start();
        }
    }

    public void OnButtonPress(int index)
    {
        if (index >= 0 && index < spriteGroups.Length)
        {
            spriteGroups[index].OnButtonPress();
        }
    }

    public void ResetButton(int index)
    {
        if (index >= 0 && index < spriteGroups.Length)
        {
            spriteGroups[index].ResetButton();
        }
    }

}
