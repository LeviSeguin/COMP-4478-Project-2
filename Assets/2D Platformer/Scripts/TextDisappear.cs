using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisappear : MonoBehaviour
{

    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("makeTextDisappear", 5);
    }

    public void makeTextDisappear() {
        text.text = "";
    }


}
