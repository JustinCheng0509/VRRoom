using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pedestalSlider : MonoBehaviour
{
    public Slider rotationSlider;
    private float angleSliderNumber;
    [SerializeField] float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angleSliderNumber = rotationSlider.value * speed;
        this.transform.rotation = Quaternion.Euler(0, angleSliderNumber, 0);
    }
}
