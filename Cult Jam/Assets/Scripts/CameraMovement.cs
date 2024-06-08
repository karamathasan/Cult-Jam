using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        Vector2 cameraXY = (Vector2)player.transform.position + 0.05f * player.movement.rb.velocity;
        Vector3 cameraPos = new Vector3(cameraXY.x, cameraXY.y, -10);
        Camera.main.transform.position =  cameraPos;    
    }
}
