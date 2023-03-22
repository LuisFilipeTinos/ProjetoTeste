using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GemTrigger : MonoBehaviour
{
    PlayerHealth playerHealth;
    GameObject player;
    TextMeshProUGUI healthText;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            healthText = GameObject.FindGameObjectWithTag("Health").gameObject.GetComponent<TextMeshProUGUI>();

            playerHealth.Health--;
            healthText.text = playerHealth.Health.ToString();

            if (playerHealth.Health == 0)
            {
                player = GameObject.FindGameObjectWithTag("Player").gameObject;
                Destroy(player.gameObject);
            }

            Destroy(this.gameObject);
        }
    }
}
