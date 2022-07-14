using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    
    [SerializeField]
    private GameObject _eneymContainer;
    
    private double _maxDownPosition = -6.4f;
    private float _defaultY = 8f;
    private int _waitTime = 5;
    private bool _stopSpawning = false;
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return StartCoroutine(nameof(SpawnRoutine));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
        while (!_stopSpawning)
        {
            GameObject newEnemy = Instantiate(_enemyPrefab, new Vector3((float)GenerateRandomNumber(), _defaultY, 0), Quaternion.identity);
            newEnemy.transform.parent = _eneymContainer.transform;
            yield return new WaitForSeconds(_waitTime);
        }
    }
    
    private double GenerateRandomNumber()
    {
        Random random = new Random();

        return random.NextDouble() * (-_maxDownPosition - _maxDownPosition) + _maxDownPosition;
        
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
