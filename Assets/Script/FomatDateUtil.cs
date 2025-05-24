using System;
using UnityEngine;

public class FomatDateUtil : MonoBehaviour {
    public static string stringDateToSlash(string date) {
        string[] dateParts = date.Split("-");
        Array.Reverse(dateParts);
        return string.Join("/", dateParts);
    }
}
