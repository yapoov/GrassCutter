using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StageState { None, Selected, Done }
public class Stage : MB {
    
    public Text levelTxt;
    
    public StageState state = StageState.None;
    
    public void SetState (StageState state) {
        if (this.state != state) {
            this.state = state;
            go.Gc<Animator> ().Play ("Stage" + state);
        }
    }
}