using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;

    private void Awake()
    {
        if(GameManager.instance != null){
            Destroy(gameObject);
            return;
        }
        instance = this;
        
        DontDestroyOnLoad(gameObject);
    }

    public List<Sprite> PlayerSprite;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;
    public List<string> states;

    //References;

    public Player player;

    public FloatingTextManager floatingTextManager;

    public List<string> Inventory;

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize,color,position,motion,duration);
    }
    // Logic


    public int pesos;
    public int experience;

    //Save State
    /*
    * preferredSkin
    * pesos
    * experience
    */

    public void SaveState()
    {
        string s = "";
        s += "0" + "|";
        s += pesos.ToString() + "|";
        s += experience + "|";
        PlayerPrefs.SetString("SaveState", s);
        s += "0";
        Debug.Log("SaveState");
    }

    public void LoadState(Scene s)
    {

        if(!PlayerPrefs.HasKey("SaveState")){
            return;
        }
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        pesos = int.Parse(data[1]);
        experience = int.Parse(data[1]);
        Debug.Log("LoadState");
    }
}
