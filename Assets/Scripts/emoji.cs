using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class emoji : MonoBehaviour
{
    float alpha;
    public float fadetime;
    float sizex, sizey;
    // Start is called before the first frame update
    void Start()
    {
        alpha = 0;
        sizex = 0;
        sizey = 0;
        Invoke("hide", fadetime);
    }

    // Update is called once per frame
    void Update()
    {
        if ( sizey+2*Time.deltaTime <= 0.45f)
        {
            sizex += Time.deltaTime;
            sizey += 5*Time.deltaTime;
            transform.localScale = new Vector3(0.47f, sizey, 1);

        }
        //alpha += 2*Time.deltaTime;
        //GetComponent<Image>().color = new Color(255, 255, 255, alpha);
    }
    void hide()
    {
        this.gameObject.SetActive(false);
    }
}
