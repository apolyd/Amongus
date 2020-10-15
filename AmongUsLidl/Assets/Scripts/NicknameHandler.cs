using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class NicknameHandler : MonoBehaviour
{

    public void SetupNickname()
    {
        PhotonNetwork.NickName = GetComponent<InputField>().text;
        Debug.Log("Nickname is: "+PhotonNetwork.NickName);
    }
}
