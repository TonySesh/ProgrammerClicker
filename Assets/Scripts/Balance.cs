using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class Balance : MonoBehaviour
{
    public Text mainSceneBalanceText1; // Ссылка на текстовый элемент с балансом на основной сцене
    public Text shopBalanceText1; // Ссылка на текстовый элемент с балансом в магазине
    public Text mainSceneBalanceText2; // Ссылка на текстовый элемент с балансом на основной сцене
    public Text shopBalanceText2; // Ссылка на текстовый элемент с балансом в магазине

    //

    //

    private void Start()
    {
        //
        // Получаем компонент Score из текущего объекта или родительского
      
        //
        UpdateBalanceDisplay(); // Обновляем баланс при старте магазина
    }

    public void UpdateBalanceDisplay()
    {
        if (mainSceneBalanceText2 != null && shopBalanceText2 != null)
        {
            //
            // Обновляем текстовые элементы

            //

            // Получаем текст из основного элемента и дублируем его в магазине
            shopBalanceText2.text = mainSceneBalanceText2.text;
        }

        if (mainSceneBalanceText1 != null && shopBalanceText1 != null)
        {
            //
            // Обновляем текстовые элементы
            
            //

            // Получаем текст из основного элемента и дублируем его в магазине
             shopBalanceText1.text = mainSceneBalanceText1.text;
        }
    }

    public void OpenShop()
    {
        // Логика открытия магазина (например, включение UI)
        UpdateBalanceDisplay(); // Обновляем текст баланса при открытии магазина
    }


    //

    }

