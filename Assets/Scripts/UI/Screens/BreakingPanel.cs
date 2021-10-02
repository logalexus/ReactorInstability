using UnityEngine;
using System.Collections;

public class BreakingPanel : IteractPanel
{
    [SerializeField] private Breaking _breaking;
    public override void Open()
    {
        base.Open();
        _breaking.FixBreaking(()=>
        {
            Close();
        });
    }

}
