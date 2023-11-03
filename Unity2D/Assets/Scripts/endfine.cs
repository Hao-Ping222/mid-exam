using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endfine : MonoBehaviour
{
    public static string debugScenName;
    public static int startPointNumber;
    public GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("player");
        if (!playerObject)
        {
            SceneManager.LoadScene("End");
            debugScenName = SceneManager.GetActiveScene().name;
        }
        if (startPointNumber != 0) {
            GameObject g = GameObject.Find(startPointNumber.ToString()) as GameObject;
            if (g != null) {
                playerObject.transform.position = g.transform.position;
            }
            startPointNumber = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {



    }
}
