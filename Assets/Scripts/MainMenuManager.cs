using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    void Start()
    {
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
    }

    public void StartGame()
    {
        StartCoroutine(StartPlaying());
    }

    public IEnumerator StartPlaying()
    {
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

        scoreAnim.Play("FadeInText");
        scoreLabelAnim.Play("FadeInText");
        healthAnim.Play("FadeInText");
        healthLabelAnim.Play("FadeInText");
    }
}
