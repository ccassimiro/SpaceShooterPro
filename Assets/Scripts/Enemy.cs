using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;

    private float _defaultY = 8f;
    private double _maxDownPosition = -6.4f;

    // Start is called before the first frame update
    void Start()
    {
        // transform.position = new Vector3((float)GenerateRandomNumber(), _defaultY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < _maxDownPosition)
        {
            RepositionEnemy();
        }
    }

    private void RepositionEnemy()
    {
        transform.position = new Vector3((float)GenerateRandomNumber(), _defaultY, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Player"))
        {
            HandlePlayerColision(other);
        }
        else if (other.transform.tag.Equals("Laser"))
        {
            HandleLaserColision(other);
        }
        
    }

    #region ColliderHandlers
    private void HandlePlayerColision(Collider other)
    {
        Player player = other.transform.GetComponent<Player>();
        if (player)
        {
            player.Damage();
        }
            
        Destroy(gameObject);
    }

    private void HandleLaserColision(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
    #endregion

    private double GenerateRandomNumber()
    {
        Random random = new Random();

        return random.NextDouble() * (-_maxDownPosition - _maxDownPosition) + _maxDownPosition;
    }
}
