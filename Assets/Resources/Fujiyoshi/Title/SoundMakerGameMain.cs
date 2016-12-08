using UnityEngine;
using System.Collections;

public class SoundMakerGameMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Sound.LoadBgm("TitleBgm", "Title");
        Sound.LoadSe("Ok", "Ok");

        Sound.PlayBgm("TitleBgm");
    }
	
	
}
