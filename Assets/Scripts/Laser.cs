using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8f;

    private float _maxLaserPosition = 8f;

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        if (transform.position.y > _maxLaserPosition)
        {
            Destroy(gameObject);
        }
    }
}
