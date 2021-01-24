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


    public List<GameObject> itens;
    public string level;
    GameObject goal;

    public void setGoal(GameObject goal)
    {
        this.goal = goal;
    }

    public void AddItem(GameObject item){
        itens.Add(item);
    }
    public void RemoveItem(GameObject item){
        itens.Remove(item);
        VictoryCondition();
    }
    void VictoryCondition(){
        if(itens.Count < 1){
            goal.SetActive(true);
        }
    }

    public void ReloadScene(){
        SceneManager.LoadScene(level);
    }
    public void LoadScene(string level){
        SceneManager.LoadScene(level);
    }
    public void QuitGame(){
        Application.Quit();
    }

}
