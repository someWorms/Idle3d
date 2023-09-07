using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    public ulong clickUpBasePrice = 5;
    public ulong clickUpPriceMultiplier = 1;

    public TextMeshProUGUI descField;
    public AutominerModel model;
    void Start()
    {
        descField = GetComponentInChildren<TextMeshProUGUI>();

        model = new AutominerModel();
        model.Description = "Click+1\nPrice: ";
        model.Cuantity = 1;
        model.Price = clickUpBasePrice * clickUpPriceMultiplier;
        model.Empowerment = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        descField.text = model.Description + model.Price.ToString() + "\n Level: " + model.Cuantity.ToString();
    }
    
    public void Buy()
    {
        if(MoneyController.GetMoney() >= model.Price)
        {
            MoneyController.RemoveMoney(model.Price);
            ClickHandler.UpdateClick(model.Empowerment);
            model.Price = (ulong)1.5 * ((clickUpBasePrice * model.Cuantity * clickUpPriceMultiplier) * 5 / 2);
            model.Cuantity++;
        }
    }
}
