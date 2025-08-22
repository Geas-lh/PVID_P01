using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    //En resumen, este script controla el disparo periódico de un objeto en el juego,
    //reproduce una animación de ataque y crea balas en un punto de lanzamiento específico cuando se cumple el tiempo de espera establecido.

    private float waitedTime; //Esta variable privada almacena el tiempo que se ha esperado desde el último disparo.
    public float waitTimeToAttack = 3f; //Esta variable pública determina cuánto tiempo debe esperar el objeto entre cada disparo.
                                        //Puedes configurar este valor en el Inspector de Unity para ajustar la frecuencia de disparo.

    public Animator animator; //Referencia al componente Animator que se utiliza para controlar las animaciones del objeto
    public GameObject bulletPrefab; //El GameObject (objeto de juego) que se instanciará como una bala cuando el objeto dispare.
    public Transform punto_lanzamiento; //El punto de origen desde el cual se lanzará la bala cuando el objeto dispare. (GameObject)
                                        //Este punto se utiliza para determinar la posición inicial y la dirección de la bala.

    void Start()
    {
        waitedTime = waitTimeToAttack; //Esto asegura que el objeto espere el tiempo correcto antes de su primer disparo.
    }

    void Update()
    {
        if (waitedTime <= 0) //Comprueba si waitedTime es menor o igual a 0. Si es así,
                             //significa que ha pasado el tiempo de espera y el objeto debe disparar.
        {
            waitedTime = waitTimeToAttack; //Se reinicia
            animator.Play("attack"); //Reproduce una animación llamada "attack" a través del componente animator
            Invoke("LanzarBala", 0.5f); //Invoca la función LanzarBala() con un retraso de 0.5 segundos usando Invoke().
        }
        else
        {
            waitedTime -= Time.deltaTime;
        }
    }

    void LanzarBala() //Esta función se encarga de instanciar una nueva bala definida en el Prefab bulletPrefab
    {
        GameObject newBullet; //Esto crea una nueva instancia del prefab Bullet
        //La nueva instancia se moverá desde el punto de lanzamiento en la dirección en la que esté orientado el objeto.
        newBullet = Instantiate(bulletPrefab, punto_lanzamiento.position, punto_lanzamiento.rotation);
    }
}
