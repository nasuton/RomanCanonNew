using UnityEngine;
using System.Collections;

public class EnemyMasterTable : MasterTableBase<EnemyMaster>
{
    private static readonly string FilePath = "save";
    public void Load() { Load(FilePath); }
}

public class EnemyMaster : MasterBase
{
    public int rank { get; private set; }

    public int score { get; private set; }
}
