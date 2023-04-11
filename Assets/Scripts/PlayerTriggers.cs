using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTriggers : MonoBehaviour
{
    [SerializeField]
    PlayerHealth playerHealth;

    [SerializeField]
    PlayerScore playerScore;

    SpriteRenderer spriteRenderer;

    private bool isTakingDamage;

    [SerializeField]
    TextMeshProUGUI healthText;

    [SerializeField]
    TextMeshProUGUI scoreText;

    [SerializeField]
    MainMenuManager mainMenuManager;

    [SerializeField]
    CameraShake cameraShake;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        isTakingDamage = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gem"))
        {
            playerScore.Score++;
            scoreText.text = playerScore.Score.ToString();
        }
        else if (collision.gameObject.CompareTag("Enemy") && !isTakingDamage)
        {
            playerHealth.Health--;
            healthText.text = playerHealth.Health.ToString();

            if (playerHealth.Health == 0)
                EndGame();
            else
                StartCoroutine(TakeDamage());
        }

        Destroy(collision.gameObject);
    }

    public void EndGame()
    {
        if (playerHealth.Health == 0)
        {
            var spawners = GameObject.FindGameObjectsWithTag("Spawner");
            foreach (var item in spawners)
                Destroy(item);

            mainMenuManager.GameOver();
            Destroy(this.gameObject);
        }
    }

    private IEnumerator TakeDamage()
    {
        isTakingDamage = true;
        cameraShake.intensity = 0.2f;
        yield return new WaitForSeconds(0.4f);
        cameraShake.intensity = 0f;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.09f);
        spriteRenderer.color = Color.white;
        yield return new WaitForSeconds(0.09f);
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.09f);
        spriteRenderer.color = Color.white;
        yield return new WaitForSeconds(0.09f);
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.09f);
        spriteRenderer.color = Color.white;
        yield return new WaitForSeconds(0.09f);
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.09f);
        spriteRenderer.color = Color.white;
        yield return new WaitForSeconds(0.09f);
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.09f);
        spriteRenderer.color = Color.white;
        yield return new WaitForSeconds(0.09f);
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.09f);
        spriteRenderer.color = Color.white;
        yield return new WaitForSeconds(0.09f);
        isTakingDamage = false;
    }
}
