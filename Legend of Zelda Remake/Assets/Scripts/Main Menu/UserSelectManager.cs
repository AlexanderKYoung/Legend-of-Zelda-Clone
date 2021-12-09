using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserSelectManager : MonoBehaviour
{
    private GameObject[] cursorList;
    private int cursor;
    private int listLength;

    private float lastKeyPress;
    public float timeBetweenPresses = 0.25f;

    //---------
    public static User player1;
    public static User player2;
    public static User player3;

    public GameObject player1_display;
    public GameObject player2_display;
    public GameObject player3_display;
    public Text player1_name;
    public Text player2_name;
    public Text player3_name;
    public GameObject player1_password;
    public GameObject player2_password;
    public GameObject player3_password;
    public InputField player1_password_field;
    public InputField player2_password_field;
    public InputField player3_password_field;

    public GameObject RegisterYourName;
    public InputField Register_Username;
    public InputField Register_Password;
    public InputField Register_ID;

    private bool cursorIsFree;

    // Start is called before the first frame update
    void Start()
    {
        cursorIsFree = true;
        cursorList = new GameObject[4];
        int i = 0;
        foreach(Transform t in transform.Find("Hearts"))
        {
            cursorList[i] = transform.Find("Hearts").GetChild(i).gameObject;
            i++;
        }
        cursor = 0;


        listLength = 4;
        lastKeyPress = Time.time;

        cursorList[cursor].SetActive(true);
        print("List length: " + listLength);


        //---------INITIALIZE PLAYERS ON MENU------------

        //player1_display = GameObject.Find("Canvas").transform.Find("File Select").Find("Player_Name1").gameObject;
        //player2_display = GameObject.Find("Canvas").transform.Find("File Select").Find("Player_Name2").gameObject;
        //player3_display = GameObject.Find("Canvas").transform.Find("File Select").Find("Player_Name3").gameObject;

        //if (player1_display != null)
        player1_display.SetActive(true);
        //if (player2_display != null)
        player2_display.SetActive(true);
        //if (player3_display != null)
        player3_display.SetActive(true);

        player1_name.gameObject.SetActive(true);
        player2_name.gameObject.SetActive(true);
        player3_name.gameObject.SetActive(true);


        //------------
        player1 = Database.GetUser(0);
        player2 = Database.GetUser(1);
        print(player1.userName);
        getCurrentUsers();
    }

    // Update is called once per frame
    void Update()
    {
        //------------TEST LOAD SCENE---------------
        /*
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            print("Before load scene: " + Time.time);
            SceneManager.LoadScene("SampleScene");
        }*/

        if (cursorIsFree)
        {
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                if (Time.time - lastKeyPress > timeBetweenPresses)
                {
                    UpdateCursor("decrement");
                    if (cursor == 0)
                        cursor = listLength - 1;
                    else
                        cursor = (cursor - 1) % listLength;
                    lastKeyPress = Time.time;
                }
            }
            else if (Input.GetAxisRaw("Vertical") < 0)
            {
                if (Time.time - lastKeyPress > timeBetweenPresses)
                {
                    UpdateCursor("increment");
                    cursor = (cursor + 1) % listLength;
                    lastKeyPress = Time.time;
                }
            }
        }

        //----------------------------------------------
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(cursor <= 2)
            {
                if(cursor == 0)
                {
                    if(player1 != null)
                    {
                        player1_password.SetActive(true);
                        cursorIsFree = false;
                    }
                }
                else if(cursor == 1)
                {
                    if(player2 != null)
                    {
                        player2_password.SetActive(true);
                        cursorIsFree = false;
                    }
                }
                else if(cursor == 2)
                {
                    if (player3 != null)
                    {
                        player3_password.SetActive(true);
                        cursorIsFree = false;
                    }
                }
            }
            //---REGISTER---
            else if(cursor == 3)
            {
                if(RegisterYourName != null)
                {
                    RegisterYourName.SetActive(true);
                    cursorIsFree = false;
                }
            }
        }
    }

    private void UpdateCursor(string str)
    {
        print(cursor);
        if(cursorList[cursor] != null)
        {
            if (str.Equals("decrement"))
            {
                //if we are decrementing cursor, then it goes UP the screen... if cursor wraps to bottom (index 3), then index 3+1%4 = 0, index 0 set FALSE
                print(cursor);
                if (cursor == 0)
                {
                    cursorList[listLength - 1].gameObject.SetActive(true);
                    cursorList[cursor].SetActive(false);
                }
                else
                {
                    cursorList[(cursor - 1) % listLength].gameObject.SetActive(true);
                    cursorList[cursor].SetActive(false);
                }
            }
            else if (str.Equals("increment"))
            {
                print(cursor);
                cursorList[(cursor + 1) % listLength].gameObject.SetActive(true);
                cursorList[cursor].SetActive(false);
            }
        }
    }


    //-------------------
    private void getCurrentUsers()
    {
        if(player1 != null)
        {
            player1_display.gameObject.SetActive(true);
            player1_name.text = player1.userName;
        }
        else 
        { 
            player1_display.gameObject.SetActive(false);
            player1_name.text = null;
        }

        if (player2 != null)
        {
            player2_display.gameObject.SetActive(true);
            player2_name.text = player2.userName;
        }
        else 
        { 
            player2_display.gameObject.SetActive(false);
            player2_name.text = null;
        }

        if (player3 != null)
        {
            player3_display.gameObject.SetActive(true);
            player3_name.text = player3.userName;
        }
        else 
        { 
            player3_display.gameObject.SetActive(false);
            player3_name.text = null;
        }
    }

    private void selectUser()
    {

    }


    public void submitPassword(string button)
    {
        if (button.Equals("one"))
        {
            if(player1 != null)
            {
                if (player1_password_field.text.Equals(player1.password))
                {
                    SceneManager.LoadScene("SampleScene");
                }
            }
        }
        else if (button.Equals("two"))
        {
            if (player2 != null)
            {
                if (player2_password_field.text.Equals(player2.password))
                {
                    SceneManager.LoadScene("SampleScene");
                }
            }
        }
        else if (button.Equals("three"))
        {
            if (player2 != null)
            {
                if (player2_password_field.text.Equals(player2.password))
                {
                    SceneManager.LoadScene("SampleScene");
                }
            }
        }

        else if (button.Equals("four"))
        {
            print("Button equaal 3");
            if (Register_Username != null && Register_Password != null && Register_ID != null)
            {
                print("REGISTERED!!!");
                User temp = new User();
                temp.userName = Register_Username.text;
                temp.password = Register_Password.text;
                temp.userID = int.Parse(Register_ID.text);

                player3 = temp;

                SceneManager.LoadScene("SampleScene");
            }
        }
    }

}
