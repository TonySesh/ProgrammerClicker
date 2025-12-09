using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button4 : MonoBehaviour
{
    public GameObject[] sprites; // Массив спрайтов, которые нужно сделать видимыми
    private int currentSpriteIndex = 0; // Индекс текущего спрайта
    public Button button; // Ссылка на кнопку
    public GameObject messageText; // Ссылка на текстовый элемент

    void Start()
    {
        // Убедитесь, что все спрайты изначально невидимы
        foreach (var sprite in sprites)
        {
            sprite.SetActive(false);
        }

        // Убедитесь, что кнопка активна в начале
        button.interactable = true;
        messageText.SetActive(true); // Убедитесь, что текстовый элемент видим в начале
    }

    public void ShowNextSprite()
    {
        // Проверяем, есть ли доступные спрайты
        if (sprites.Length == 0) return;

        // Если текущий индекс меньше длины массива, делаем спрайт видимым
        if (currentSpriteIndex < sprites.Length)
        {
            sprites[currentSpriteIndex].SetActive(true); // Делаем спрайт видимым
            currentSpriteIndex++; // Увеличиваем индекс для следующего спрайта

            // Если все спрайты показаны, отключаем кнопку и скрываем текст
            if (currentSpriteIndex >= sprites.Length)
            {
                button.interactable = false; // Делаем кнопку неактивной
                messageText.SetActive(false); // Скрываем текстовый элемент
            }
        }
    }
}
