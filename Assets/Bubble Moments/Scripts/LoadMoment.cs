using UnityEngine;
using System.Collections;

public class LoadMoment : MonoBehaviour {

    public string url = "https://docs.unity3d.com/uploads/Main/ShadowIntro.png";

    // Use this for initialization
    IEnumerator Start () {
        Texture2D tex;
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
        WWW www = new WWW(url);
        yield return www;
        www.LoadImageIntoTexture(tex);
        GetComponent<Renderer>().material.mainTexture = tex;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
