using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Money : MonoBehaviour
{
    private TextMeshProUGUI moneyText;

    private void Start()
    {
        moneyText = GetComponent<TextMeshProUGUI>();
        moneyText.text = "Money: " + LocalDB.Instance.db.data.money;
    }

    internal void updateMoney()
    {
        moneyText.text = "Money: " + LocalDB.Instance.db.data.money;
    }
}
