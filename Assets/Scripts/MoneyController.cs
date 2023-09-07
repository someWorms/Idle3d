using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyController : MonoBehaviour
{
    private static ulong money;
    public TextMeshProUGUI moneyField;
    // Start is called before the first frame update
    void Start()
    {
        moneyField.text = "0 $";
    }

    // Update is called once per frame
    void Update()
    {
        moneyField.text = $"{money} $";
    }

    public static void AddMoney(ulong cuantity)
        => money += cuantity;
    public static ulong GetMoney() 
        => money;
    public static void RemoveMoney(ulong cuantity)
        => money -= cuantity;
}
