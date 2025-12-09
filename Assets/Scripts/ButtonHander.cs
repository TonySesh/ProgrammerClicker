using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Rimuru.UI
{


    public class ButtonHander : MonoBehaviour
    {

        public AudioSource audioSource; // Ссылка на источник звука

        public Button muteButton1;       // Кнопка для отключения звука
        public Button unmuteButton1;     // Кнопка для включения звука
        public Button muteButton2;       // Кнопка для отключения звука
        public Button unmuteButton2;     // Кнопка для включения звука
        public Button muteButton3;       // Кнопка для отключения звука
        public Button unmuteButton3;     // Кнопка для включения звука


        private void Start()
        {
           
            // Назначаем методы на события нажатия кнопок
            muteButton1.onClick.AddListener(MuteSound);
            unmuteButton1.onClick.AddListener(UnmuteSound);
            muteButton2.onClick.AddListener(MuteSound);
            unmuteButton2.onClick.AddListener(UnmuteSound);
            muteButton3.onClick.AddListener(MuteSound);
            unmuteButton3.onClick.AddListener(UnmuteSound);
        }

        void MuteSound()
        {
            audioSource.mute = true; // Отключаем звук
        }

        void UnmuteSound()
        {
            audioSource.mute = false; // Включаем звук
        }

        public void OpenAndCloseUIPanel(GameObject panel)
        {
            if (panel.Equals(null)) ;
            panel.SetActive(!panel.activeInHierarchy);
        }

    }

}