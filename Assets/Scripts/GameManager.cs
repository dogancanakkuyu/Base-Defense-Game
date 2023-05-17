using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    [SerializeField] Transform spawnPosition;
    [SerializeField] Skeleton skeletonPrefab;
    [SerializeField] GameObject visualEffect;
    private int spawnEnemyCount;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        spawnEnemyCount = 10;
    }

    private void Start()
    {
        visualEffect.SetActive(true);
        StartCoroutine(SpawnCoroutine());
    }

    void SpawnSkeleton()
    {
        Instantiate(skeletonPrefab, spawnPosition.position, Quaternion.identity);
    }

    IEnumerator SpawnCoroutine()
    {
        for (int i = 0; i < spawnEnemyCount; i++)
        {
            SpawnSkeleton();
            yield return new WaitForSeconds(2.0f);
        }
        
       
    }
}
