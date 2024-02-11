using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClampScript : MonoBehaviour
{

    public GameObject player;
    public float cameraHeight;
    public float cameraDepth;
    public float leftClamp;
    public float rightClamp;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Mathf.Clamp(this.player.transform.position.x, leftClamp, rightClamp), cameraHeight, cameraDepth);
    }
}
