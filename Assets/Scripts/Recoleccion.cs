using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoleccion : MonoBehaviour //Metodo para hacer efecto de aparecer particulas cuando el objeto principal desaparece
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision) //metodo para saber si el objeto asignado con el script esta colisionando con otro objeto
    {
        if (collision.transform.CompareTag("Player")) //Si colisiona valida si el objeto colisionado tiene un tag con el nombre "Player"
        {
            GetComponent<SpriteRenderer>().enabled = false; //Esto sirve para obtener del objeto asignado con el script extraiga el componente en este caso SpriteRenderer
                                                           //dentro de su atributo enabled colocar "false", para hacer invisible el objeto.
            gameObject.transform.GetChild(0).gameObject.SetActive(true); // Esta línea de código se utiliza para activar el primer hijo del objeto
                                                                         // en el que se encuentra el script. Puede ser útil, por ejemplo, para mostrar u ocultar objetos hijos.
            Invoke("CollectedFruit", 0.5f); //Esto sirve para programar la llamada a la función "CollectedFruit" después de un breve retraso de 0.5 segundos.
        }
    }

    public void CollectedFruit()
    {
        Destroy(gameObject); //Destruye el objeto que se hizo invisible o desactivo en este caso el SpriteRenderer
    }
}
