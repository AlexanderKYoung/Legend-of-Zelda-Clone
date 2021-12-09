using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New User Database", menuName = "Assets/Databases/Player Database")]
public class UserDatabase : ScriptableObject
{
    public List<User> userDatabase;
}
