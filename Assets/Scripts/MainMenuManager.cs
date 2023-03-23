using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    PlayerController player;

    [SerializeField]
    SpawnerController enemySpawner;

    [SerializeField]
    SpawnerController objectSpawner;

    [SerializeField]
    SpawnerController beettleSpawner;
    
    [SerializeField]
    SpawnerController batSpawner;

    [SerializeField]
    Animator miniFadeAnim;

    [SerializeField]
    Animator titleAnim;

    [SerializeField]
    Animator startAnim;

    [SerializeField]
    Animator exitAnim;

    [SerializeField]
    Animator scoreAnim;

    [SerializeField]
    Animator healthAnim;

    [SerializeField]
    Animator scoreLabelAnim;

    [SerializeField]
    Animator healthLabelAnim;

    [SerializeField]
    Animator gameOverAnim;

    [SerializeField]
    Animator restartAnim;

    [SerializeField]
    Button startButton;

    [SerializeField]
    Button exitButton;

    [SerializeField]
    Button restartButton;

    void Start()
    {
        startButton.interactable = false;
        restartButton.interactable = false;
        exitButton.interactable = false;

        Invoke("CallFadeIn", 2f);
        Invoke("CallTextFadeIn", 2.5f);
    }

    public void CallFadeIn()
    {
        miniFadeAnim.Play("MiniFadeInTransition");
    }
    public void CallTextFadeIn()
    {
        titleAnim.Play("FadeInText");
        startAnim.Play("FadeInButton");
        exitAnim.Play("FadeInButton");

        startButton.interactable = true;
        exitButton.interactable = true;

        restartButton.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        StartCoroutine(StartPlaying());
    }

    public IEnumerator StartPlaying()
    {
        startButton.interactable = false;
        exitButton.interactable = false;

        titleAnim.Play("FadeOutText");
        startAnim.Play("FadeOutButton");
        exitAnim.Play("FadeOutButton");
        yield return new WaitForSeconds(0.6f);
        miniFadeAnim.Play("MiniFadeOutTransition");
        yield return new WaitForSeconds(0.3f);

        //Possibilita a movimentação do player e a ativação dos spawners:
        player.canMove = true;
        enemySpawner.canSpawn = true;
        objectSpawner.canSpawn = true;
        beettleSpawner.canSpawn = true;
        batSpawner.canSpawn = true;

        scoreAnim.Play("FadeInText");
        scoreLabelAnim.Play("FadeInText");
        healthAnim.Play("FadeInText");
        healthLabelAnim.Play("FadeInText");

        startButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        StartCoroutine(FinishGame());
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private IEnumerator FinishGame()
    {
        yield return new WaitForSeconds(0.6f);
        miniFadeAnim.Play("MiniFadeInTransition");

        gameOverAnim.Play("FadeInText");
        restartAnim.Play("FadeInButton");
        exitAnim.Play("FadeInButton");

        exitButton.interactable = true;
        restartButton.interactable = true;
    }
}
