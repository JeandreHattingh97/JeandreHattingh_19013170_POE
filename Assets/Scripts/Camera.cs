using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] float cameraSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraMove();
        CameraZoom();
    }

    void CameraZoom()
    {
        if (Input.GetKey(KeyCode.E))
        {
            transform.position += new Vector3(0, -cameraSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.position += new Vector3(0, cameraSpeed * Time.deltaTime, 0);
        }
    }

    void CameraMove()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        transform.position += new Vector3(cameraSpeed * Time.deltaTime * horizontal, 0, cameraSpeed * Time.deltaTime * vertical);
    }
}

