using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] Slider slider;
    [SerializeField] Image image;
    // Start is called before the first frame update
    void Start()
    {
        if (!slider) { Debug.LogError("There is not slider assigned to in HealthBarManager"); Destroy(this); }
    }
    public void SwitchSprite(int index)
    {
        image.sprite = sprites[index];
    }
}
