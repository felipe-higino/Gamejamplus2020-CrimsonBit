using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoopManager : MonoBehaviour
{
    public static GameLoopManager instance;
    private void Awake() {
        if(instance!=null)
            Destroy(this);
        instance = this;
    }


    public List<Item> itens;
    public string level;
    public GameObject goal;
    public void AddItem(Item item){
        itens.Add(item);
    }
    public void RemoveItem(Item item){
        itens.Remove(item);
    }
    void VictoryCondition(){
        if(itens.Count < 1){
            goal.SetActive(true);
        }
    }

    public void ReloadScene(){
        SceneManager.LoadScene(level);
    }

}
