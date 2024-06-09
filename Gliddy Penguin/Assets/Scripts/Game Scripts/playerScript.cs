using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class playerScript : MonoBehaviour
{
    public int moveSpeed = 3;
    public int leftRightSpeed = 2;

    // 0 = left; 1 = middle; 2 = right
    public int desiredLane = 1;
    public float laneDistance = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        if (Input.GetKeyDown(KeyCode.D))
        {
            // increment desiredLane (move to right)
            desiredLane++;

            // player can't move right if they are already on right
            // can be changed later if we want
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            // increment desiredLane (move to left)
            desiredLane--;

            // player can't move left if they are already on left
            // can be changed later if we want
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

        // move player to desired lane
        // idk how this works, all I know is my previous solution didn't work because i never heard of GetKeyDown
        Vector3 targetPos = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPos += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPos = Vector3.right * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position, targetPos, 10 * Time.deltaTime);
    }
}
