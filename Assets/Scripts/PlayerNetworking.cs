﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

// https://www.youtube.com/watch?v=pGmYGI1LlE4
public class PlayerNetworking : MonoBehaviour
{
    public MonoBehaviour[] scriptsToIgnore;

    private PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (!photonView.IsMine)
        {
            foreach(var script in scriptsToIgnore)
            {
                script.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}