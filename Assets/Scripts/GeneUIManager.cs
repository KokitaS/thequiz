using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class GeneUIManager : MonoBehaviourPunCallbacks
{
    public static GeneUIManager instance;
    [SerializeField] TextMeshProUGUI GeneratingText;
    [SerializeField] GameObject GeneratePanel;
    public TextMeshProUGUI player1_genre_box;
    public TextMeshProUGUI player2_genre_box;

    public List<PlayerInfo> playerList = new List<PlayerInfo>();
    private object[] info = new object[2];

    private void Awake()
    {
        instance = this;
    }

    public GameObject playerPrefab;
    private GameObject player;

    private void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Instantiate(playerPrefab.name,new Vector3(0,0,0),Quaternion.identity);
        }
    }

    public void CloseGeneUI()
    {
        GeneratePanel.SetActive(false);
    }
    public void GeneratingUIDisplay()
    {
        CloseGeneUI();
        GeneratePanel.SetActive(true);

    }
    public void SetGeneratingText(string _text)
    {
        GeneratingText.text = _text;
    }

    public void UpdatePlayerInfo()
    { 
        if (PhotonNetwork.IsMasterClient)
        {
            photonView.RPC("SetGenre_Player1",RpcTarget.All,MessageGeter.genre);    
        }
        else
        {
            photonView.RPC("SetGenre_Player2",RpcTarget.All,MessageGeter.genre);    
        }
    }

    [PunRPC]
    public void SetGenre_Player1(string newGenre)
    {
        player1_genre_box.text = newGenre;   
    }
    [PunRPC]
    public void SetGenre_Player2(string newGenre)
    {
        player2_genre_box.text = newGenre;   
    }

    [System.Serializable]
    public class PlayerInfo
    {
        public string name;
        public string jyanru;

        public PlayerInfo(string _name, string _jyanru)
        {
            name = _name;
            jyanru = _jyanru;
        }
    }
    
}
