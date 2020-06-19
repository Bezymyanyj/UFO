using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Explossion : MonoBehaviour
{
    private bool isFailed;
    public ParticleSystem explosion;
    public GameObject deathBody;
    public GameObject body;
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
            explosion.Play();
            deathBody.SetActive(true);
            body.SetActive(false);
        }
    }
}
