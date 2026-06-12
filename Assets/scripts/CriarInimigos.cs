using UnityEngine;
using System.Collections;

public class CriarInimigos : MonoBehaviour
{
    public GameObject inimigoPrefab; //vai ser vir para arrastar o inimigos e vai criar oq tiver aqui
    public GameObject inimigoVidaPrefab; //vai criar inimigo do tipo vida
    public GameObject inimigoTempoPrefab; // vai criar inimigo do tipo tempo
    public float tempoSpawn = 4f; // gerenciar o tempo de aparecimento
    public float tempoSpawnVida = 4f;//tempo de aparecimento do inimigo tipo vida
    public float tempoSpawnTempo;//tempo de aparecimento do inimigo tipo tempo
    public raycast player;

    void Start()
    {
        tempoSpawnTempo = Random.Range(15f, 20f);

        StartCoroutine(SpawnarInimigosNormais());//vai criar inimigos

        StartCoroutine(SpawnarInimigosTempo());//vai criar inimigos de tempo

        StartCoroutine(SpawnarInimigosVida());//vai criar inimigos de vida

        StartCoroutine(AumentarDificultadade());//vai deixar mais dificil a cada tempo :), se eu deixar isso no update ele vai repetir o codigo 50 vezes :/
    }

   
    void Update()
    {

       

    }

    IEnumerator SpawnarInimigosTempo()//cria inimigoTempo/inimigo3
    {
        while (true)
        {
            


            float x = 0f;//precisa ser fixo pois nao tem como mexer a camera
            float y = 3f;

            Vector3 posicao = new Vector3(x, y, 0);// aqui to falando que a "posicao" e o vector 3 do inimigos como a posicao x e posicao y, o Z vai ser zero mesmo

            GameObject novoInimigoTempo = Instantiate(inimigoTempoPrefab, posicao, Quaternion.identity);// vai criar o inimigo, (Quaternion.identity) vai fazer que o objeto fica reto e nao fica rotacionando.

            inimigo dados = novoInimigoTempo.GetComponent<inimigo>();// vai pegar o dados do script inimigo

            StartCoroutine(TempoDeVida3(novoInimigoTempo, dados.dano));

            Debug.Log("tempo de surgimento do inimigo tempo = " + tempoSpawnTempo);

            yield return new WaitForSeconds(tempoSpawnTempo);
        }

    }


    IEnumerator SpawnarInimigosVida()//cria inimigoVida/inimigo2
    {
        while (true)
        {
            float x = Random.Range(-4.5f, 4.5f);
            float y = Random.Range(1f, 3f);

            Vector3 posicao = new Vector3(x, y, 0);// aqui to falando que a "posicao" e o vector 3 do inimigos como a posicao x e posicao y, o Z vai ser zero mesmo

            GameObject novoInimigoVida = Instantiate(inimigoVidaPrefab, posicao, Quaternion.identity);// vai criar o inimigo, (Quaternion.identity) vai fazer que o objeto fica reto e nao fica rotacionando.

            inimigo dados = novoInimigoVida.GetComponent<inimigo>();// vai pegar o dados do script inimigo

            StartCoroutine(TempoDeVida2(novoInimigoVida, dados.dano));

            yield return new WaitForSeconds(tempoSpawnVida);
        }

    }

        IEnumerator SpawnarInimigosNormais()
        {
            while (true)
            {
                float x = Random.Range(-4.5f, 4.5f);
                float y = Random.Range(1f, 3f);

                Vector3 posicao = new Vector3(x, y, 0);// aqui to falando que a "posicao" e o vector 3 do inimigos como a posicao x e posicao y, o Z vai ser zero mesmo

                GameObject novoInimigo = Instantiate(inimigoPrefab, posicao, Quaternion.identity);// vai criar o inimigo, (Quaternion.identity) vai fazer que o objeto fica reto e nao fica rotacionando.

                inimigo dados = novoInimigo.GetComponent<inimigo>();// vai pegar o dados do script inimigo

                StartCoroutine(TempoDeVida(novoInimigo, dados.dano));

                yield return new WaitForSeconds(tempoSpawn);
            }


        }
        IEnumerator TempoDeVida(GameObject inimigo, float dano)// isso vai fazer que o inimigo tiver vivo ele vai dar dano e morre
        {
            yield return new WaitForSeconds(4f);

            if (inimigo != null)
            {
                player.vida -= dano;

                Destroy(inimigo);

                Debug.Log("tomou dano do tipo 1");
            }
        }





        IEnumerator TempoDeVida2(GameObject inimigo2, float dano)// isso vai fazer que o inimigo2 tiver vivo ele vai dar dano e morre 
        {
            yield return new WaitForSeconds(3f);

            if (inimigo2 != null)
            {
                player.vida -= dano;

                Destroy(inimigo2);

                Debug.Log("tomou dano do tipo 2");
            }
        }


    IEnumerator TempoDeVida3(GameObject inimigo3, float dano)// isso vai fazer que o inimigo3 tiver vivo ele vai dar dano e morre 
    {
        yield return new WaitForSeconds(2f);

        if (inimigo3 != null)
        {
            player.vida -= dano;

            Destroy(inimigo3);

            Debug.Log("tomou dano do tipo 3");
        }
    }

    IEnumerator AumentarDificultadade()
        {
            yield return new WaitForSeconds(9f);

            while (true)
            {
                if (tempoSpawn >= 0.5f)//quanto mais tempo passa mais dificil fica 
                {
                    tempoSpawn -= 0.2f;

                    Debug.Log("deminui o tempo");
                }
            if (tempoSpawnVida >= 0.5f)//quanto mais tempo passa mais dificil fica 
            {
                tempoSpawnVida -= 0.2f;

                Debug.Log("deminui o tempo do tipo vida");
            }
            yield return new WaitForSeconds(4f);
            }
        }

    }
