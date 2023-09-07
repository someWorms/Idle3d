using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeAutoController : MonoBehaviour
{
    public ulong autoUpBasePrice = 15;
    public ulong autoUpPriceMultiplier = 1;

    public TextMeshProUGUI descField;
    public AutominerModel model;

    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    void Start()
    {
        descField = GetComponentInChildren<TextMeshProUGUI>();

        model = new AutominerModel();
        model.Description = "Auto+1\nPrice: ";
        model.Cuantity = 0;
        model.Price = autoUpBasePrice * autoUpPriceMultiplier;
        model.Empowerment = 1;

    }

    // Update is called once per frame
    void Update()
    {
        descField.text = model.Description + model.Price.ToString() + "\n Level: " + model.Cuantity.ToString();
        if(model.Cuantity != 0)
        {
            if (Time.time > nextActionTime)
            {
                nextActionTime += period;
                model.AddFunds += model.Empowerment;
                MoneyController.AddMoney(model.AddFunds);
            }
        }
    }

    public void Buy()
    {
        if (MoneyController.GetMoney() >= model.Price)
        {
            MoneyController.RemoveMoney(model.Price);
            ClickHandler.UpdateClick(1);
            model.Price = (ulong)1.5 * ((autoUpBasePrice * model.Cuantity * autoUpPriceMultiplier) * 9 / 2);
            model.Empowerment += 1;/**/
            model.Cuantity++;
        }
    }
}
