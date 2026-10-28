using System.Collections;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] int amount = 100;
    [SerializeField] float delay = 0.05f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        for (int i = 0; i < amount; i++ )
        {
            Vector3 pos = new Vector3(
                Random.Range(-2f, 2f),
                8f,
                Random.Range(-2f, 2f));

            Instantiate(ballPrefab, pos, Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
    }
}
