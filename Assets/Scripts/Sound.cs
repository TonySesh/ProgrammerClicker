using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sound : MonoBehaviour
{

    public Button soundButton; // Кнопка для управления звуком


    public Sprite soundOnSprite; // Иконка звука включена
    public Sprite soundOffSprite; // Иконка звука выключена


    private bool isSoundOn = true; // Состояние звука
    private bool isMusicOn = true; // Состояние музыки

    void Start()
    {
        UpdateButtonIcons();
        AudioListener.volume = isSoundOn ? 1 : 0; // Устанавливаем начальное состояние звука
        // Если у вас есть AudioSource для музыки, вы можете настроить его здесь
    }

    public void ToggleSound()
    {
        isSoundOn = !isSoundOn; // Переключаем состояние звука
        UpdateButtonIcons();
        AudioListener.volume = isSoundOn ? 1 : 0; // Включаем или выключаем звук
    }

    public void ToggleMusic()
    {
        isMusicOn = !isMusicOn; // Переключаем состояние музыки
        UpdateButtonIcons();

        if (isMusicOn)
        {
            // Включите вашу мелодию здесь, например:
             GetComponent<AudioSource>().Play();
        }
        else
        {
            // Остановите вашу мелодию здесь, например:
             GetComponent<AudioSource>().Stop();
        }
    }

    private void UpdateButtonIcons()
    {
        soundButton.image.sprite = isSoundOn ? soundOnSprite : soundOffSprite;
        
    }
}

