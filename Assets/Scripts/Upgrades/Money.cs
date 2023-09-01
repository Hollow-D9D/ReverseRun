using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Money : MonoBehaviour
{
    private TextMeshProUGUI moneyText;

    private void Start()
    {//Money:
        moneyText = GetComponent<TextMeshProUGUI>();
        moneyText.text = "" + LocalDB.Instance.db.data.money;
    }

    internal void updateMoney()
    {//Money:
        moneyText.text = "" + LocalDB.Instance.db.data.money;
    }
}
