using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public class SplashScreenController : MonoBehaviour {
    public Image logoImage;
    public GameObject splashScreenObj;

    void Start() {
        StartCoroutine(fadeImage(2f, logoImage));
    }

    public IEnumerator fadeImage(float time, Image image) {
        yield return new WaitForSeconds(3);

        for (float i = 1; i >= 0; i -= Time.deltaTime / time) {
            image.color = new Color(1, 1, 1, i);
            yield return null;
        }

        yield return new WaitForSeconds(0.3f);

        splashScreenObj.SetActive(false);
    }
}
