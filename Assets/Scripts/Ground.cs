using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public static bool IsGround;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsGround=true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsGround=false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
