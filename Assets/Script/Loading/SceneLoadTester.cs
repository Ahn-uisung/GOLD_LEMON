using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SceneLoadTester : MonoBehaviour
{
    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadingSceneController.LoadScene("GameScene");
        }
    }
}
