using UnityEngine;
using System.Collections;

// Soundの登録をするクラスです
// 呼ぶ前に必ずここに登録してください


public class SoundMaker : MonoBehaviour
{
    void Start()
    {
        Sound.LoadSe("TitleBgm", "Title");
        Sound.LoadSe("kasutamu_k", "kasutamu_k");
    }
}
