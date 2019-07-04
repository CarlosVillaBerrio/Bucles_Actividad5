using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsferasDeColores : MonoBehaviour
{
    public bool activador; // Hace de boton y activa la generacion de esferas
    bool esferasCreadas;   // Determina si las esferas fueron creadas 
    GeneradorDeEsferas esferasGeneradas = new GeneradorDeEsferas(); // Instancia de la clase generadora de las esferas
    
    public class GeneradorDeEsferas // Crea esferas de colores en filas y columnas aleatorias entre 3 y 12
    {
        public int filas; // Variable para las filas
        public int columnas; // Variable para las columnas
        public int colorAleatorio; // Variable para elegir el color aleatorio de las esferas
        public Material Materialito; // Variable para asignar material a las esferas
        ComparadorDeEsferas comparar = new ComparadorDeEsferas(); // Instancia de la clase comparadora
        public GameObject esferaAnterior; // Creacion de la variable Gameobject esferaAnterior
        public GameObject esferaActual; // Creacion de la variable Gameobject esferaActual

        public void GeneradorEsferasPintadas() // Metodo para crear esferas pintadas
        {  
            filas = Random.Range(3, 12); // Comando para generar de forma aleatoria filas
            columnas = Random.Range(3, 12); // Comando para generar de forma aleatoria columnas
            for (int i = 0; i < filas; i++) // Ciclo "for" anidado para crear las esferas
            {
                for (int j = 0; j < columnas; j++) // segunda parte del ciclo anidado
                {
                    esferaActual = GameObject.CreatePrimitive(PrimitiveType.Sphere); // Comando para generar un gameobject tipo esfera
                    esferaActual.GetComponent<Renderer>().material = Materialito; // Comando para asignar material a la esfera
                    esferaActual.transform.position = new Vector3(j * 2.0f, i * 2.0f, 0f); // Comando para ubicar a las esferas
                    colorAleatorio = Random.Range(0, 6); // Comando para asignar un numero a la variable colorAleatorio
                    switch (colorAleatorio) // Conjunto de opciones que asigna un color a la esfera
                    {
                        case 0:
                            esferaActual.GetComponent<Renderer>().material.color = Color.blue; // Esfera azul
                            break; // Rompe y continua la siguiente iteracion del ciclo
                        case 1:
                            esferaActual.GetComponent<Renderer>().material.color = Color.cyan; // Esfera azul claro
                            break; // Rompe y continua la siguiente iteracion del ciclo
                        case 2:
                            esferaActual.GetComponent<Renderer>().material.color = Color.yellow; // Esfera amarilla
                            break; // Rompe y continua la siguiente iteracion del ciclo
                        case 3:
                            esferaActual.GetComponent<Renderer>().material.color = Color.green; // Esfera verde
                            break; // Rompe y continua la siguiente iteracion del ciclo
                        case 4:
                            esferaActual.GetComponent<Renderer>().material.color = Color.magenta; // Esfera rosada
                            break; // Rompe y continua la siguiente iteracion del ciclo
                        case 5:
                            esferaActual.GetComponent<Renderer>().material.color = Color.red; // Esfera roja
                            break; // Rompe y continua la siguiente iteracion del ciclo
                        case 6:
                            esferaActual.GetComponent<Renderer>().material.color = Color.white; // Esfera blanca
                            break; // Rompe y continua la siguiente iteracion del ciclo
                    }
                    
                    comparar.ComparadorEsferasPintadas(j, esferaAnterior, esferaActual); // Clase con la funcion de comparar esferas y volverlas negras
                    esferaAnterior = esferaActual; // Actualizador del valor de la esfera anterior. Se debe actualizr el parametro de la clase por fuera
                }
            }
        }
    }

    public class ComparadorDeEsferas // Compara esferas de la misma fila. Si se tiene 2 o mas del mismo color seguidas, se vuelven negras
    {
        public void ComparadorEsferasPintadas(int contador, GameObject esferaAnterior, GameObject esferaActual) // Metodo de comparacion
        {
            if (contador > 0 && esferaAnterior != null) // Condicion para evitar salida de error de referencia nula a la primera iteracion
            {
                if (esferaAnterior.GetComponent<Renderer>().material.color == esferaActual.GetComponent<Renderer>().material.color) // Condicional especifico para las esferas
                {
                    esferaAnterior.GetComponent<Renderer>().material.color = Color.black; // Convierte la esfera anterior en negra
                    esferaActual.GetComponent<Renderer>().material.color = Color.black; // Convierte la esfera actual en negra
                }
            }
        }
    }

    void Start() // Esto no hace nada
    {
        
    }

    void Update()
    {
        if (activador) // Condicional para la casilla del activador
        {
            activador = false; // Cambia el estado de la casilla a falso
            if (!esferasCreadas) // Condicional que nos muestra las esferas creadas si no se han creado
            {
                esferasGeneradas.GeneradorEsferasPintadas();
                esferasCreadas = true;
            }
            else
                UnityEngine.SceneManagement.SceneManager.LoadScene(0); // Reinicia la escena
        }        
    }
}