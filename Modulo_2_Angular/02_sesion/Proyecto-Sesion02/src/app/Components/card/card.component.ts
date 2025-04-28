import { Component } from '@angular/core';

@Component({
  selector: 'app-card',
  imports: [],
  templateUrl: './card.component.html',
  styleUrl: './card.component.css'
})
export class CardComponent {
  title = "Esto es una card";
  contenido = "Esto es una card que vamos a estar trabajando"
  botonText = "Conocer más..."
  img = "https://picsum.photos/640/640?r" + Math.random()
}
