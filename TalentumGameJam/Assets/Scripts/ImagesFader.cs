using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ImagesFader : MonoBehaviour {
    private bool allImagesDidFade, isFading, mustFade;
    private int currentImageToFade;
    public SpriteRenderer[] imagesToFade;
	
	void Start()
    {
        allImagesDidFade = false;
        isFading = false;
        mustFade = false;
        currentImageToFade = 0;
    }
	void Update () {
        if(Input.GetMouseButtonDown(0)) {            
            if (!allImagesDidFade && !isFading) {
                mustFade = true;
            } else {
                Debug.Log("Finished fading or is actually fading");
            }
        }
        if(mustFade) {
            fadeImage();            
        }

	}

    private void fadeImage()
    {        
        if(currentImageToFade < imagesToFade.Length-1 ){
            isFading = true;
            if (imagesToFade[currentImageToFade].color.a > 0) {
                Color fadedColor = imagesToFade[currentImageToFade].color;
                fadedColor.a -= Time.deltaTime * 0.5f;
                imagesToFade[currentImageToFade].color = fadedColor;
            }else {
                mustFade = false;
                isFading = false;
                Debug.Log("End fading image " + currentImageToFade);
                currentImageToFade++;
            }
            
        } else {
            SceneManager.LoadScene("Menu");            
        }
        
    }
}
