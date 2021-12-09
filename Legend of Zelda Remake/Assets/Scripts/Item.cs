using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour 
{ 
    //atributes for all items
    public string coinName;
    public int coinValue;

    void Start() {
        //get the first 5 of the object name
        coinName = name.Substring(0, 5);
        //Debug.Log(coinName);
        switch (coinName)
        //bombs and keys hijack the coin system for ease of use
        {
            case "Coin1":
                coinValue = 1;
                    break;
            case "Coin5":
                coinValue = 5;
                break;
            case "Bombs":
                coinValue = 1;
                break;
            case "Keyes":
                coinValue = 1;
                break;
        }
    }
    public bool isitem() {
        return true;
    }
}
