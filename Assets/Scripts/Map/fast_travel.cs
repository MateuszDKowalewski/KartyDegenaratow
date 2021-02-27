using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fast_travel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        if (gameObject.name == "GoToMap")
        {
            Application.LoadLevel("Map");
        }
        if (gameObject.name == "GoTomap2")
        {
            Application.LoadLevel("map2");
        }
    }
}
/*
  ____  ____  ____  ____
 /\   \/\   \/\   \/\   \
/  \___\ \___\ \___\ \___\
\  / __/_/   / /   / /   /
 \/_/\   \__/\/___/\/___/
   /  \___\    /  \___\
   \  / __/_  _\  /   /
    \/_/\   \/\ \/___/
      /  \__/  \___\
      \  / _\  /   /
       \/_/\ \/___/
         /  \___\
         \  /   /
          \/___/
*/