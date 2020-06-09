using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    private bool isFailed;
    public ParticleSystem explotion;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake() => Messenger.AddListener("Level_Failed", OnFailed);
    
    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy() => Messenger.RemoveListener("Level_Failed", OnFailed);
    
    private void OnFailed(){
        if(!isFailed){
            isFailed = true;
            explotion.Play();
        }
    }
}
