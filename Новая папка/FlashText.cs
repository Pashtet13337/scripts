using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashText : MonoBehaviour
{

    static public int flash;

    [SerializeField]
    public Text textflash;
    // Start is called before the first frame update
    void Start()
    {
        flash = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
