using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Hud : MonoBehaviour
{
    public raycast player;
    public TextMeshProUGUI textoVida;
    public TextMeshProUGUI Tempo;


    void Start()
    {
        
    }

   
    void Update()
    {
        textoVida.text = "Vida: " + player.vida;
        Tempo.text = "Tempo: " + player.tempoRestante;
    }
}
