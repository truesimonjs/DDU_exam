using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SJS_PlayerController player;
    public int score = 0;
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
}
