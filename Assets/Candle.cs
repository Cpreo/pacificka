using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    // Start is called before the first frame update
    UnityEngine.Rendering.Universal.Light2D sceneLight;
    bool active = false;
    public string state1 = "Candle1";
    void Start()
    {
        sceneLight = gameObject.transform.Find("Global Light").GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        active = gameObject.GetComponent<Torch>().activated;
        if(active && sceneLight.intensity < 0.5f){
            sceneLight.intensity += 0.02f * Time.deltaTime;
        }
        if(sceneLight.intensity == 0.5f && !GameManager.instance.states.Contains(state1)){
            GameManager.instance.states.Add(state1);
        }
        if(GameManager.instance.states.Contains(state1)){
            active = true;
            sceneLight.intensity = 0.5f;
        }
    }
    void FixedUpdate(){
    }
}
