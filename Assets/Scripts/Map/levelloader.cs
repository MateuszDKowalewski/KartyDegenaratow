﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelloader : MonoBehaviour
{
    public int iLevelToLoad;
    public string sLevelToLoad;
    public bool useIntigerToLoadLevel = false;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.name == "Player")
        {
            LoadScene();
        }
    }

    void LoadScene()
    {
        if (useIntigerToLoadLevel)
        {
            SceneManager.LoadScene(iLevelToLoad);
        }
        else
        {
            SceneManager.LoadScene(sLevelToLoad);
        }
    }
}

/*
                                       .
                                      /|
                                     / |
                                    /  |
                                   / | |
                                  / /| |
        ..''''..                 / / | |
     .'          '.             / /  | |
   .'              '           ' '   ' |
  .'                '.         | |  /  |                         ___..--.
 '                    \        ' `.' .-......,       ....---""'':... ,.'
'                      \        \  ."`       ''\   .' _..--''""' .'.'
'                       '       ''             '.' .'         ,','
'' '' ''..              |      .`                 .'........-- ;' 
' '  '  ' '             | .'''|           ."".     ;'''''''''''
 '        .''           .'    | ."".      || |     -
  \         .'        .''     | || |      |  |     |
   `..      ,.'_____  | '     | |  |      '..'     |
      `.    |       `"*  '. .'|  ""   ..           |.
        '.  '         |    '  |    .  ..  .        .' `
          \/         .'   '   '.    ''  ''      .,'    '
                    '    '      `..          .''        '
                   |     '      /  `''''''''' \         '
                   |     |'    /               \       '
                   '     | '  .                 \    .'
                    \    |  ''|                 //','
                     `---'   ''                .'
                             | \             ,'/
                             |  `.         .' /
                             |    |'^.,,.'  /
                             '..-'  |       /
                                    |      /
                                    |     /
                                     '...'
                                    
Bodziix was here
*/