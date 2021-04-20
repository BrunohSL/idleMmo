using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FireInUsePrefabUi : MonoBehaviour {
    public Image image;

    public void setSprite(string sprite) {
        this.image.sprite = Resources.Load<Sprite>(sprite);
    }
}
