using UnityEngine;
using System.Collections;

public class enemyInstantiate : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Vector3 position;
    public Quaternion rotation;

    private GameObject enemy;

    void Start()
    {
        enemy = Instantiate(enemyPrefab, position, rotation) as GameObject;
    }
}
