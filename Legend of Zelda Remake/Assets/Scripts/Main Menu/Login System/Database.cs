using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public UserDatabase users;

    private static Database instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //use database, get a user...
    public static User GetUser(int id)
    {
        foreach(User user in instance.users.userDatabase)
        {
            if (user.userID == id)
                return user;
        }

        return null;
    }
}
