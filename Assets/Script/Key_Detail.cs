using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Detail : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Deactivate", 15.0f);
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
