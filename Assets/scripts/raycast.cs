using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class raycast : MonoBehaviour
{
    LineRenderer lr;
    public float velocidade = 5f;
    public float vida = 3f;
    public float tempoRestante = 65f;
    public GameObject telaGameOver;
    public GameObject telaVitoria;

    void Start()
    {
        lr = GetComponent<LineRenderer>();// o componente que serve para deixar o raio visivel na cena

    }

    
    void Update()
    {   
        if(tempoRestante < 0)//deixar o numero quebrado me incomoda, por isso vou deixar ele zero mesmo
        {
            tempoRestante = 0;
        }


        if( vida == 3f)// vai arrumar o bug de nao voltar o jogo hehe
        {
            Time.timeScale = 1f;
        }

        if (vida <= 0 || tempoRestante <= 0)
        {
            if (Input.GetKeyDown(KeyCode.R))//vai resetar o jogo bro
            {
                Time.timeScale = 1f;// volta o tempo  (na teoria, pois ele nao esta voltando normalmente, tive que criar uma funçao para voltar realmente :/)

                SceneManager.LoadScene(0);// reinicia a cena
            }
        }

        if (vida >= 4) { // e um limitador de vida, para a vida nao ir mais do que 3
        
            vida = 3;

        }



        if (vida  > 0) {


            //funçao para diminuir o tempo
            tempoRestante -= Time.deltaTime;

            if (tempoRestante <= 0)//tela de vitoria
            {
                telaVitoria.SetActive(true);

                Time.timeScale = 0f;

                Debug.Log("ganhou");

            }




            if (Input.GetMouseButtonDown(0)) { 

                //aqui e o ray do mouse
                Ray rayMouse = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitDataMouse;

            if (Physics.Raycast(rayMouse, out hitDataMouse, 200f))
            {
                if (hitDataMouse.collider.CompareTag("inimigoTipo2"))//faz que o clique do mouse so acerte o inimigo tipo do vida.
                {
                        

                    Debug.Log("Acertou um inimigo tipo vida");

                    Destroy(hitDataMouse.collider.gameObject);

                        float chanceCura = Random.Range(1, 5);// faz que a cura tem uma chance de curar.

                        Debug.Log("rodou " + chanceCura);

                        if (chanceCura >= 4) { 
                       
                            vida += 1;
                            Debug.Log("curou");

                        }




                }


            }
          }
            //-------------------------------------------------//(para separar os tipos de ray)




             if (Input.GetKeyDown(KeyCode.Space))//faz o player atirar no meio da tela(vou fazer ainda)
            {
                Ray rayCentro = Camera.main.ViewportPointToRay(new Vector3 (0.5f, 0.5f, 0)); //vai colocar o ray no centro da tela

                Debug.DrawRay(rayCentro.origin, rayCentro.direction * 200f, Color.green, 2f);

                RaycastHit HitDataCentro;

                if(Physics.Raycast(rayCentro , out HitDataCentro , 200f))
                {
                    if (HitDataCentro.collider.CompareTag("inimigoTipo3"))
                    {
                        Debug.Log("Acertou um inimigo tipo tempo");

                        Destroy(HitDataCentro.collider.gameObject);

                        tempoRestante -= 5f;
                    }
                }

            }

            //-------------------------------------------------//(para separar os tipos de ray)



            //aqui em baixo e o ray direto do bloco
            Ray ray = new Ray(transform.position, transform.up);

            Debug.DrawRay(transform.position, Vector3.up * 10000f, Color.red, 4f);
               
      
                 lr.SetPosition(0, transform.position);//fala a posiçao do raio
                lr.SetPosition(1, transform.position + transform.up * 100f);// tamanho do raio


                RaycastHit hitData;

            if (Physics.Raycast(transform.position, transform.up, out hitData, 200f))//diz onde o raio vai sair e fala pra ver se vai bater em algo e o tamanho
            {


                 if (hitData.collider.CompareTag("Inimigo"))//compara a tag e se for diferente nao bate
                 {

                Debug.Log("Acertou um inimigo tipo normal");

                    Destroy(hitData.collider.gameObject);
                }

   
              }


            if (transform.position.x >= -4.5f)/*limita a posiçao do player*/ {
                if (Input.GetKey(KeyCode.A))//faz o player andar para a esquerda
             {

                transform.Translate(Vector3.left * velocidade * Time.deltaTime);

                //Debug.Log("apertou esquerda");

             }
            }

            if (transform.position.x <= 4.5f) { 
                if (Input.GetKey(KeyCode.D))//faz o player andar para a direita
               {

                    transform.Translate(Vector3.right * velocidade * Time.deltaTime);
                //Debug.Log("apertou direita");
             
            }
          }
        }
        if (vida <= 0)
        {
            telaGameOver.SetActive(true);//na unity isso ta desativado e quando perde ele ativa

            Time.timeScale = 0f;

            Debug.Log("morreu");


        }

      



    }
}
