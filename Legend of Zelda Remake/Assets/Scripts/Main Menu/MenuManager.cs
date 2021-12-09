using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject RegisterMenu;
    public GameObject LoginMenu;

    private User activeUser;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;


    // Start is called before the first frame update
    void Start()
    {
        StartMenu.SetActive(true);
        RegisterMenu.SetActive(false);
        LoginMenu.SetActive(false);

        GameObject.Find("Canvas").transform.Find("File Select").gameObject.SetActive(false);

        //player1 = GameObject.Find("Canvas").transform.Find("File Select").Find("Player_Name1").gameObject;
        //player2 = GameObject.Find("Canvas").transform.Find("File Select").Find("Player_Name2").gameObject;
        //player3 = GameObject.Find("Canvas").transform.Find("File Select").Find("Player_Name3").gameObject;

        //player1.SetActive(false);
        //player2.SetActive(false);
        //player3.SetActive(false);

        player1 = null;
        player2 = null;
        player3 = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            StartMenu.SetActive(false);
            LoginMenu.SetActive(true);
            GameObject.Find("Canvas").transform.Find("File Select").gameObject.SetActive(true);
        }
    }
}
