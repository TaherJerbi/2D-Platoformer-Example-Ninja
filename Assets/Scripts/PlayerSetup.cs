using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {
    [SerializeField]
    Behaviour[] componentsToDisable;

    [SerializeField]
    GameObject Player;

    private bool disabled;

    // Update is called once per frame
    void Update() {
        if (Player.GetComponent<HealthManager>()._dead && !disabled)
            DisablePlayer();
	}
    public void DisablePlayer()
    {
        
        foreach (Behaviour bh in componentsToDisable)
        {
            bh.enabled = false;
        }
        disabled = true;
    }

}
