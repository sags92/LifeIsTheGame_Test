using System;
using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    public static string selectedDance;

    public static void SelectDance(string dance)
    {
        selectedDance = dance;
    }

    public static string GetActualDance()
    {
        if (selectedDance == "") throw new Exception("Dance type doesn't exist, assign it before accessing");
        return selectedDance;
    }
}
