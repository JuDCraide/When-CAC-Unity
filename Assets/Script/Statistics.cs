using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum Plataform {
    ANDROID,
    WEB,
    WINDOWS,
}

public class Statistics : MonoBehaviour {
    Plataform plataform = Plataform.ANDROID;

    public void Start() {
        if (GameManager.justStarted) {
            Debug.Log("StartGame");
            GameManager.justStarted = false;
            SendStatistics();
        }
    }

    public void SendStatistics() {
        //Debug.Log("StartGame");
        string targetUrl = Request.DEFAULT_URL_STATISTICS;
        switch(plataform) {
            case Plataform.ANDROID:
                targetUrl += "unity-android";
                break;
            case Plataform.WEB:
                targetUrl += "unity-web";
                break;
            case Plataform.WINDOWS:
                targetUrl += "unity-windows";
                break;
        }
        if (!String.IsNullOrEmpty(GameManager.seed)) {
            targetUrl += $"?seed={GameManager.seed}";
        }
        this.StartCoroutine(Request.GetRequestRoutine(targetUrl, this.SendStatisticsResponseCallback));
    }

    // Callback to act on our response data
    private void SendStatisticsResponseCallback(string data) {
        Debug.Log("Statistics sent");
    }
}
