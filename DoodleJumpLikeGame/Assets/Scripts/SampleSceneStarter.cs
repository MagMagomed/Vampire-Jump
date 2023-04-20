using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleSceneStarter : MonoBehaviour
{
    public List<GameObject> gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        foreach(var gameObject in gameObjects)
        {
            Instantiate(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
