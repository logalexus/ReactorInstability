using UnityEngine;
using System.Collections;

public class BreakingPanel : IteractPanel
{
    [SerializeField] private Breaking _breaking;
    public override void Open(GameObject caller)
    {
        base.Open(caller);
        _breaking = caller.GetComponent<Breaking>();
        _breaking.FixBreaking(()=>
        {
            Close();
        });
    }

}
