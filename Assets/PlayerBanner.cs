using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBanner : MonoBehaviour {
    [System.Serializable]
    public class Banner
    {
        public Sprite banner;

       public  Sprite playerPose;

        public string playerName;
    }
    [SerializeField]
    Banner[] playerBanners = new Banner[4];
    private int charNum = -1;
    // Use this for initialization
    private Animator anim;
    void Start () {
        anim = GetComponent<Animator>();
        SetPlayer("blue");

    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            charNum++;
            SetPlayer("green");

        }
    }

    public void SetPlayer(string player)
    {
        switch (player.ToLower().Trim())
            {
                case "red":
                    {
                        charNum = 0;
                        break;
                    }
                case "blue":
                    {
                        charNum = 1;
                        break;
                    }
                case "green":
                    {
                        charNum = 2;
                        break;
                    }
                case "yellow":
                    {
                        charNum = 3;
                        break;
                    }
                default:
                    break;
            }
            transform.GetChild(0).GetComponent<Text>().text = playerBanners[charNum].playerName;
            transform.GetChild(1).GetComponent<Image>().sprite = playerBanners[charNum].playerPose;
            GetComponent<Image>().sprite = playerBanners[charNum].banner;
        anim.SetTrigger("Banner!");
        

    }
}
