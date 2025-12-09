using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using static ChangeSprite;


public class GG2 : MonoBehaviour

    
{
   

    [SerializeField] private int Score;
    [SerializeField] private int Iq;

    
    public ChangeSprite ChangeSprite; // Ссылка на ChangeSprite
    public Button4 Button4;
    


    public Text balanceText; // Текстовый элемент для отображения баланса
    public Text scorebalanceText;
    public Item[] items; // Массив товаров    
    public Item[] items1; //массив товаров для магазина предметов
    public Text[] itemPriceTexts2; // Массив текстовых элементов для отображения цен товаров
    public Text[] itemPriceTexts; // Массив текстовых элементов для отображения цен товаров
    public Text clicksText; // Текстовый элемент для отображения кликов
    public Text ScoreText; // Текст для отображения счета
    public Text IqText; // Текст для отображения баланса

    public Image targetImage; // Ссылка на компонент Image, который будет менять спрайты
    public Sprite player1; // Спрайт 1
    public Sprite player2; // Спрайт 2
    public Sprite player3; // Спрайт 3
    
    private int scorebalance;
    private int balance; // Начальный баланс
    private int totalClicks = 0; // Общее количество кликов
    private int currentSpriteIndex = 0; // Индекс текущего спрайта
    private float timeSinceLastClick = 0f; // Время с последнего клика
    private const float resetTime = 2f; // Время до сброса спрайта
    private int virtualIq = 0; // Виртуальное значение Iq для расчета Score


    
    private void Start()
    {
   

        scorebalance = Score;
        balance = Iq; // Начальный баланс устанавливаем из Iq
        UpdateUI();
        targetImage.sprite = player1; // Устанавливаем начальный спрайт

    }

    private void Update()
    {
        ScoreText.text = scorebalance.ToString();
        scorebalanceText.text = scorebalance.ToString();
        IqText.text = balance.ToString();
        balanceText.text = balance.ToString(); // Обновляем текст баланса
        clicksText.text = totalClicks.ToString();

        for (int i = 0; i < items.Length; i++)
        {
            itemPriceTexts[i].text = items[i].price.ToString();
        }      
        for (int i = 0; i < items1.Length; i++)
        {
            itemPriceTexts2[i].text = items1[i].price.ToString();
        }      
        timeSinceLastClick += Time.deltaTime;

        ScoreText.text = scorebalance.ToString();
        

        IqText.text = balance.ToString();

        if (Input.GetMouseButtonDown(0)) // Проверяем, был ли клик левой кнопкой мыши
        {
            
            timeSinceLastClick = 0f; // Сбрасываем время с последнего клика
                                    
                                     // Меняем спрайт на следующий
            currentSpriteIndex = (currentSpriteIndex + 1) % 2 + 2; // Переключаем между спрайтами 2 и 3
            targetImage.sprite = (currentSpriteIndex == 2) ? player2 : player3;
            

        }

        if (timeSinceLastClick >= resetTime)
        {
            targetImage.sprite = player1; // Возвращаемся к спрайту 1
        }
    }

    public void OnClickButton()
    {
        
        //Score++;
        Iq += 1+totalClicks;
        //balance += 1 + totalClicks;// Обновляем баланс при клике
                                    // Проверяем, сколько раз Iq делится на 10
                                    //int additionalScore = Iq / 10; // Количество десятков в Iq
                                    //Score += additionalScore; // Увеличиваем Score на количество десятков
                                    //Iq -= additionalScore * 10; // Уменьшаем Iq на количество десятков, чтобы оставить остаток
        virtualIq += 1 + totalClicks; // Увеличиваем виртуальное значение Iq
        balance += 1 + totalClicks; // Обновляем баланс при клике
        
        // Проверяем, сколько раз virtualIq делится на 10 и увеличиваем Score
        while (virtualIq >= 10)
        {
            Score++;
            scorebalance++;
            virtualIq -= 10; // Уменьшаем virtualIq на 10 за каждое увеличение Score
        }



            UpdateUI(); // Обновляем интерфейс после изменения
    }
    public void BuyItem1(int item1Index)
    {



        if (item1Index < 0 || item1Index >= items1.Length) return;

        Item item1 = items1[item1Index];

        if (scorebalance >= item1.price)
        {
    


            scorebalance -= item1.price; // Вычитаем цену из баланса
            //totalClicks += item.clickIncrease; // Увеличиваем клики
            item1.IncreasePrice(); // Увеличиваем цену товара
            // Вызов метода из ChangeSprite

            if (ChangeSprite != null)
            {

                if (item1Index == 3)
                {
                    Button4.ShowNextSprite();
                }
                else
                {
                    ChangeSprite.OnButtonPress(item1Index); ///////////Не удалять
                }
            }

            UpdateUI(); // Обновляем интерфейс
        
        }
        else
        {
            Debug.Log("Недостаточно средств для покупки " + item1.itemName);
        }
    }




    public void BuyItem(int itemIndex)
    {
        if (itemIndex < 0 || itemIndex >= items.Length) return;

        Item item = items[itemIndex];

        if (balance >= item.price)
        {
            balance -= item.price; // Вычитаем цену из баланса
            totalClicks += item.clickIncrease; // Увеличиваем клики
            item.IncreasePrice(); // Увеличиваем цену товара
            
            UpdateUI(); // Обновляем интерфейс
        }
        else
        {
            Debug.Log("Недостаточно средств для покупки " + item.itemName);
        }
    }

    private void UpdateUI()
    {
        IqText.text = balance.ToString();    
        ScoreText.text = scorebalance.ToString();  
        clicksText.text = totalClicks.ToString();

        for (int i = 0; i < items.Length; i++)
        {
            itemPriceTexts[i].text = items[i].price.ToString();
        }
     
        for (int i = 0; i < items1.Length; i++)
        {
            itemPriceTexts2[i].text = items1[i].price.ToString();
        }
    }
}
