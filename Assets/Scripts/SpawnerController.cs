using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    private float fixedXStartPos = -7f;
    private float fixedXFinishPos = 7.33f;

    [SerializeField]
    GameObject objectPrefab;

    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    GameObject beettlePrefab;

    [SerializeField]
    GameObject batPrefab;

    [SerializeField]
    PlayerScore playerScore;

    private float timeToSpawn = 0;
    public bool canSpawn;

    private void Start()
    {
        canSpawn = false;
    }

    void Update()
    {
        if (canSpawn)
        {
            timeToSpawn += Time.deltaTime;

            if (this.name == "ObjectSpawner" && timeToSpawn > 4f)
            {
                var randomXPos = Random.Range(fixedXStartPos, fixedXFinishPos);

                var objectInstatiated = Instantiate(objectPrefab, new Vector2(randomXPos, transform.position.y), Quaternion.identity);
                timeToSpawn = 0;
            }
            else if (this.name == "EnemySpawner" && timeToSpawn > 2f)
            {
                var randomXPos = Random.Range(fixedXStartPos, fixedXFinishPos);

                var objectInstatiated = Instantiate(enemyPrefab, new Vector2(randomXPos, transform.position.y), Quaternion.identity);
                timeToSpawn = 0;
            }
            else if (this.name == "BeettleSpawner" && timeToSpawn > 3f && playerScore.Score > 5)
            {
                var randomXPos = Random.Range(fixedXStartPos, fixedXFinishPos);

                var objectInstatiated = Instantiate(beettlePrefab, new Vector2(randomXPos, transform.position.y), Quaternion.identity);
                timeToSpawn = 0;
            }
            else if (this.name == "BatSpawner" && timeToSpawn > 8f && playerScore.Score > 10)
            {
                var randomXPos = Random.Range(fixedXStartPos, fixedXFinishPos);
                var randomXPos2 = Random.Range(fixedXStartPos, fixedXFinishPos);

                var objectInstatiated = Instantiate(batPrefab, new Vector2(randomXPos, transform.position.y), Quaternion.identity);
                var objectTwoInstatiated = Instantiate(batPrefab, new Vector2(randomXPos2, transform.position.y), Quaternion.identity);
                timeToSpawn = 0;
            }
        }
    }
}
