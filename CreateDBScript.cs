using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class CreateDBScript : MonoBehaviour {

	public Text DebugText;

    /******************/
    //Texture2D photo, img;       //two pics = WinnieThePooh & Eeyore

    public byte[] imageData;    //image byte array that wil hold texture-converted-to-png
    int width;
    int height; 
    /******************/

    // Use this for initialization
    void Start () {

        /************************/
        
        // load texture from resource folder
        Texture2D photo = new Texture2D(355, 355);  //declare texture2d to hold pic from resources folder
        Texture2D img = new Texture2D(355, 355);    //holds texture converted back from byte array 
        

        photo = Resources.Load("eeyore") as Texture2D; //load pic from resources folder into texture2d

        imageData = photo.EncodeToJPG();    //Encode texture to PNG to save as Byte Array in database
        img.LoadImage(imageData);           //try to change byte array back into a texture2d to display
                           //same thing happens if this is here or not

        GameObject rawImage = GameObject.Find("RawImage"); //Find the 'RawImage' 
        rawImage.GetComponent<RawImage>().texture = img;   //set a texture to the raw image ('photo' works,'img' doesnt)

        /*************************/
        StartSync();
    }

    private void StartSync()
    {
        var ds = new DataService("tempDatabase.db");  //constructor of DataService() takes db string name. 
        ds.CreateDB();                      ///creates database from DataService.cs
        
        var people = ds.GetTeddy ();  //returns a connection to people TABLE 
        ToConsole (teddy);
        teddy = ds.GetTeddyNamedRoberto ();
        ToConsole("Searching for Roberto ...");
        ToConsole (teddy); 
    }
	
	private void ToConsole(IEnumerable<Teddy> teddy){  //enumerable list passed
		foreach (var teddy in Tedyy) {
			ToConsole(teddy.ToString());
		}
	}
	
	private void ToConsole(string msg){
		DebugText.text += System.Environment.NewLine + msg;
		Debug.Log (msg);
	}
}
