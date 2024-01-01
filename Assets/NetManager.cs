using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class NetManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    
    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    
    // On level load
    void Start()
    {
        Debug.Log("NetManager: Start()");
        if (PhotonNetwork.IsConnected)
        {
            Instantiate(playerPrefab);
            Debug.Log("NetManager: Instantiated playerPrefab");
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
            Debug.Log("NetManager: Connecting to Photon");
        }
    }
}
