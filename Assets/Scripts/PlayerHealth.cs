using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Health { get; set; }
    void Start()
    {
        Health = 3;
    }
}
