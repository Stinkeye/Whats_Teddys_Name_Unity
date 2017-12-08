using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class newClass : MonoBehaviour {

    public byte[] imageData;    //image byte array that wil hold texture-converted-to-png
    public bool imgFlag; 
    void Start () {
        /************************/

        // load texture from resource folder
        Texture2D photo = new Texture2D(355, 355);  //declare texture2d to hold pic from resources folder
        Texture2D img = new Texture2D(355, 355);    //holds texture converted back from byte array 


        photo = Resources.Load("eeyore") as Texture2D; //load pic from resources folder into texture2d

        imageData = photo.EncodeToJPG();    //Encode texture to PNG to save as Byte Array in database
        imgFlag = img.LoadImage(imageData);           //try to change byte array back into a texture2d to display
        img.Apply();                                   //same thing happens if this is here or not

        GameObject rawImage = GameObject.Find("RawImage"); //Find the 'RawImage' 
        rawImage.GetComponent<RawImage>().texture = img;   //set a texture to the raw image ('photo' works,'img' doesnt)


    }

    // Update is called once per frame
    void Update () {
		
	}
}
