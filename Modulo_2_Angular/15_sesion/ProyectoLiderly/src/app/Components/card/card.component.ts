import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-card',
  imports: [FormsModule],
  templateUrl: './card.component.html',
  styleUrl: './card.component.css'
})
export class CardComponent {
  title = "Esto es una card";
  contenido = "Esto es una card que vamos estar trabajando";
  botonText = "Conocer más ...";
  img= "https://picsum.photos/640/640?r" + Math.random();

  nombre = "";

  mostrarAlerta() {
    alert("Hola Mine");
  }

}
