using System;
using UnityEngine;

// This script formats a date string from "YYYY-MM-DD" to "DD/MM/YYYY"
public class FomatDateUtil : MonoBehaviour {
    public static string stringDateToSlash(string date) {
        string[] dateParts = date.Split("-");
        Array.Reverse(dateParts);
        return string.Join("/", dateParts);
    }
}
