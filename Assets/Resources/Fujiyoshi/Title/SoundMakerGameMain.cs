using UnityEngine;
using System.Collections;

public class SoundMakerGameMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Sound.LoadBgm("TitleBgm", "Title");
        Sound.LoadSe("minigan r", "minigan r");
        Sound.LoadSe("minigan e", "minigan e");
        Sound.LoadSe("minigan h", "minigan h");

        Sound.LoadSe("rokeran s", "rokeran s");
        Sound.LoadSe("rokeran h", "rokeran h");

        Sound.LoadBgm("tilya-zi t", "tilya-zi t");
        Sound.LoadBgm("tilya-zi s", "tilya-zi s");
        //Sound.LoadSe("tilya-zi se", "tilya-zi se");

        //Sound.PlayBgm("TitleBgm");
    }
	
	
}
