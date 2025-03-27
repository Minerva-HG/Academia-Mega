# Sesión 1: Funcionaes y Closure

## Fecha: 26/03/2025

---

## Objetivos de la Sesión


Las funciones pueden acceder valores fuera de su contexto

Como en el ejemplo anterior, una función puede acceder y utilizar valores que están definidos fuera de su “cuerpo” o contexto, por ejemplo:


```javascript
let count = 1
function contador() {
    console.log(count)
}
contador() // imprime 1
count = 2
contador() // imprime 2

```

Esto, permite que podamos modificar el valor de la variable `count` desde cualquier parte del módulo y, cuando la función contador sea llamada, sabrá usar el valor actual.


Las funciones son la mejor forma de reutilizar y compartir código dentro de un programa.

Ahora, puedes utilizar tu función cuantas veces sean y - ignorando algunos casos particulares- llamar tu función *N *veces es lo mismo que escribir ese **trozo de código maravilloso** *N* veces. Es un simple reemplazo.


## ¿Pero dónde está el closure aquí?

Usando el ejemplo del contador, consideremos ese como el **trozo de código maravilloso**

```
let count = 1
function contador() {
    console.log(count)
}
contador() // imprime 1
```

Ahora, queremos reutilizarlo en muchas partes, por lo que lo "envolveremos" en una función.

```javascript
function miFuncion() {
    let count = 1
    function contador() {
        console.log(count)
    }
    contador() // imprime 1
}
```

ahora, que tenemos?

Una función: `contador` que utiliza un valor que fue declarado fuera de ella `count`. Y un valor: `count` que fue declarado en la función `miFuncion` pero que es usado dentro de la función `contador`.

Es decir, tenemos una función que utiliza un valor que fue declarado fuera de su contexto:  **un closure** .

¿Simple no? Ahora, ¿qué pasa cuándo se ejecuta la función `miFuncion`?, ¿qué ocurre con la variable `count` y la función `contador`?
Una vez ejecutada la función  **padre** , las variables y funciones declaradas en su cuerpo “desaparecen” (garbage collector).

Ahora, modifiquemos un poco el ejemplo:

```javascript
function miFuncion() {
    let count = 1
    function contador() {
        count++
        console.log(count)
    }
   setInterval(contador, 2000)
}
miFuncion()
```

¿Qué ocurrirá ahora con la variable y función declaradas dentro de `marvel`?
En este ejemplo, le decimos al browser que ejecute `contador` cada 2 segundos. Por lo que el engine de javascript debe mantener una referencia a la función y tambien a la variable que es utilizada por ella. Entonces, incluso una vez que la función padre `miFuncion` termine su ciclo de ejecución, la función `contador` y el valor `count` seguiran  *“viviendo”* .

Este “efecto” de tener closures ocurre por qué javascript soporta la anidación de funciones, o en otras palabras: Las funciones son **ciudadanos de primera clase** en el lenguaje y pueden ser utilizadas como cualquier otro objeto: anidadas, pasadas como argumento, como valor de retorno, etc.




## Temas Cubiertos

2. **Fundamentos de JavaScript**

* Funciones

## Ejercicios Realizados

### Ejercicio 3: Funciones

```javascript

function multiplicador (factor){
    return function(numero){
        return numero * factor;
    }
}

const duplicar = multiplicador(12);
const triplicar = multiplicador(3);

console.log(duplicar(5));
console.log(duplicar(5));

```

## Desafíos Encontrados

## Recursos Adicionales

https://www.freecodecamp.org/espanol/news/que-es-un-closure-en-javascript/

https://liderly.udemy.com/course/javascript-completo-de-cero-a-experto-en-tiempo-record/learn/lecture/45369219?course_portion_id=1154925&learning_path_id=9653047#overview

## Próximos Pasos

## Reflexiones Personales

Esta sesión me ha ayudado a comprender la reutilizacion de las variables en las funciones

---

*Entregable correspondiente a la Semana 1 del Módulo 1: JavaScript Testing*
