using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int Score { get; set; }
    void Start()
    {
        Score = 0;
    }
}
