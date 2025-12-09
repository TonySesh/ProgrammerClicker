using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName; // Имя товара
    public int price; // Цена товара
    public int clickIncrease; // Увеличение кликов

    // Метод для увеличения цены
    public void IncreasePrice()
    {
        price *= 4;
    }
}

