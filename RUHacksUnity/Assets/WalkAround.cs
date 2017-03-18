using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WalkAround : MonoBehaviour
{
    NavMeshAgent mesh;
    NavMeshHit hit;
    bool moving;
    Vector3 finalposition;
    Vector3 destinationA, destinationB, target;
    // Use this for initialization
    void Start()
    {
        destinationA = new Vector3(204.67f, 111.85f, 53.3f);
        destinationB = new Vector3(145, 101.54F, 46);
        target = this.transform.position;
        mesh = this.GetComponent<NavMeshAgent>();
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position == target)
        {
            moving = false;
        }
        if (Input.anyKeyDown && !moving)
        {
            print("Key Down");
            move();
        }
    }

    public void move()
    {
        if (target == destinationB)
        {

            target = destinationA;
        }
        else
        {
            target = destinationB;

        }
        mesh.destination = target;
    }
}