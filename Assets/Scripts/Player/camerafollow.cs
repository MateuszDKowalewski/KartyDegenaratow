using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public float followspeed, ypos;
    private Transform player;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }


    void FixedUpdate()
    {
        Vector2 targetpos = player.position;
        Vector2 smoothpos = Vector2.Lerp(transform.position, targetpos, followspeed * Time.deltaTime);
        transform.position = new Vector3(smoothpos.x, smoothpos.y + ypos, -15f);
    }
}

/*Bodziix Was Here
  ______________________
 /\                     \
/  \    _________________\
\   \   \                /
 \   \   \__________    /
  \   \   \    /   /   /
   \   \   \  /   /   /
    \   \   \/   /   /
     \   \  /   /   /
      \   \/   /   /
       \      /   /
        \    /   /
         \  /   /
          \/___/
 */