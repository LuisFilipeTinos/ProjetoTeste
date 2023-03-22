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
                Destroy(this.gameObject);
            else
                StartCoroutine(TakeDamage());
        }

        Destroy(collision.gameObject);
    }

    private IEnumerator TakeDamage()
    {
        isTakingDamage = true;
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
