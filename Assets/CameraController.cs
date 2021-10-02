using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    public float sideView;
    public float upView = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x+sideView , player.transform.position.y+upView , player.transform.position.y);
    }
}
