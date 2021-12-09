using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New User", menuName = "Assets/Scriptables/Users")]
public class User : ScriptableObject
{
    public string userName;
    public string password;

    public int userID;

    public bool isAdmin;
}
