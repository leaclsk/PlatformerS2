using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject playerRef;
    Vector3 refVelocity = Vector3.zero;
    [SerializeField] float smoothTime = 0.1f;
    [SerializeField] float i;

    // Start is called before the first frame update
    void Start()
    {       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(playerRef.transform.position.x, playerRef.transform.position.y + i, -10);
        gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, targetPosition, ref refVelocity, smoothTime);


    }

}
