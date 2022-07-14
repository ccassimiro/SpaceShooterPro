using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] // show variable on unity editor, but still private, and other game objects cant manipulate it
    private float _speed = 3.5f;

    #region Walking Limits

    private float _maxUpPosition = 0;
    private float _maxDownPosition = -3.8f; // negative side of axis
    private float _maxRightPosition = 11.3f;
    private float _maxLeftPosition = -11.3f; // negative side of axis

    #endregion


    // Start is called before the first frame update
    private void Start()
    {
        // take the current position and set new position to (0, 0, 0)
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    private void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        // player movement
        transform.Translate(direction * _speed * Time.deltaTime);

        // limiting where the player can walk on Y axis
        transform.position = new Vector3(transform.position.x,
            Mathf.Clamp(transform.position.y, _maxDownPosition, _maxUpPosition), 0);

        // limiting where the player can walk on X axis
        if (transform.position.x >= _maxRightPosition)
        {
            transform.position = new Vector3(_maxLeftPosition, transform.position.y, 0);
        }
        else if (transform.position.x <= _maxLeftPosition)
        {
            transform.position = new Vector3(_maxRightPosition, transform.position.y, 0);
        }
    }
}