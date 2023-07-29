using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    //Encapsulation
    public static MainManager instance { get; private set; }
    private int m_selectedHeroNumber = 0;
    public int selectedHeroNumber
    {
        get { return m_selectedHeroNumber; }
        set
        {
            if (value < 0)
            {
                Debug.LogError("You can't set a negative hero number!");
            }   
            else
            {
                m_selectedHeroNumber = value;
            }
        }
    }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
