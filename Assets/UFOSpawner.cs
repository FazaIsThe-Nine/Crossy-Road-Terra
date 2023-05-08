using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawner : MonoBehaviour
{
    [SerializeField] UFO ufo;
    [SerializeField] player player;
    [SerializeField] float initialTimer = 10;
    float timer;

    void Start() {
        timer = initialTimer;
        ufo.gameObject.SetActive(false);
    }

    void Update() {
        if(timer<=0 && ufo.gameObject.activeInHierarchy == false)
            {
                ufo.gameObject.SetActive(true);
                ufo.transform.position = player.transform.position + new Vector3(0,0,20);
                player.SetMoveable(false);
            }
        
        timer -= Time.deltaTime;
    }
    public void ResetTimer () 
    {
        timer = initialTimer;
    }
}
