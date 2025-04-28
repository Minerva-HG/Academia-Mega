import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-card',
  imports: [FormsModule],
  templateUrl: './card.component.html',
  styleUrl: './card.component.css'
})
export class CardComponent {
  title = "Esto es un ejemplo de ngModel";
  contenido = "Esto es una card que vamos a estar trabajando"
  botonText = "Conocer más..."
  img = "https://picsum.photos/640/640?r" + Math.random()
  imgMegacable = "https://inversionistas.megacable.com.mx/images/bg/megacable_.jpg"

  nombre = "Minne"

  mostrarAlerta(){
    alert("Hola Minerva godinez");
  }
}