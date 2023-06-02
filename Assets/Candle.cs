using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    // Start is called before the first frame update
    UnityEngine.Rendering.Universal.Light2D sceneLight;
    bool active;
    void Start()
    {
        sceneLight = gameObject.transform.Find("Global Light").GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        active = gameObject.GetComponent<Torch>().activated;
        if(active && sceneLight.intensity < 0.5f){
            sceneLight.intensity += 0.04f * Time.deltaTime;
        }
    }
    void FixedUpdate(){
    }
}
