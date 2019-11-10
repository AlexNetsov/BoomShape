using UnityEngine;
using System.Collections;

public class DeadScreen : MonoBehaviour {

    public static DeadScreen instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }
}	