using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GemTrigger : MonoBehaviour
{
    PlayerHealth playerHealth;
    GameObject player;
    TextMeshProUGUI healthText;
    MainMenuManager mainMenuManager;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerHealth>();
        mainMenuManager = GameObject.Find("MainCanvas").gameObject.GetComponent<MainMenuManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && playerHealth.Health > 0)
        {
            healthText = GameObject.FindGameObjectWithTag("Health").gameObject.GetComponent<TextMeshProUGUI>();

            playerHealth.Health--;
            healthText.text = playerHealth.Health.ToString();

            if (playerHealth.Health == 0)
            {

                var spawners = GameObject.FindGameObjectsWithTag("Spawner");
                foreach (var item in spawners)
                    Destroy(item);

                mainMenuManager.GameOver();
                player = GameObject.FindGameObjectWithTag("Player").gameObject;
                Destroy(player.gameObject);
            }

            Destroy(this.gameObject);
        }
    }
}
