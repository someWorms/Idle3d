using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    private static ulong _click = 1;
    private static int _modifier = 1;

    private Ray _ray;
    private RaycastHit _hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(_ray, out _hit, 1000f))
            {
                if(_hit.transform == transform) 
                {
                    Debug.Log("Clicked GameObject");
                    MoneyController.AddMoney(_click * (ulong)_modifier);
                }
            }
        }
    }

    public static void UpdateClick(ulong click)
    {
        _click += click;
    }
}
