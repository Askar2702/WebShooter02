using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] int startBalance = 100;
    [SerializeField] int currentBalance;

    private void Start()
    {
        currentBalance = startBalance;
    }

    public void GetMoney(int money)
    {
        currentBalance += money;
    }

    public void ReduceMoney(int reduceMoney)
    {
        currentBalance -= reduceMoney;
    }

    public void SetStartBalance()
    {
        currentBalance = startBalance;
    }
}
