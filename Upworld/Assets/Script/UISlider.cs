using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISlider : MonoBehaviour
{
    public Transform lava;
    public Transform player;
    public Transform clearZone;

    public Image lava_UI_Image;
    public Slider player_UI_Image;

    void Update()
    {
        lava_UI_Image.fillAmount = lava.position.y / clearZone.position.y;
        player_UI_Image.value = player.position.y / clearZone.position.y;

    }
}
