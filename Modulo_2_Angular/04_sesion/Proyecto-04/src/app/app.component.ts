import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Saludo } from './Components/Saludo/saludo.component';
import { CardComponent } from './Components/card/card.component';
import { TarjetaComponent } from './Components/tarjeta/tarjeta.component';
import { CommonModule } from '@angular/common';
import { TodoComponent } from './Components/todo/todo.component';

@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet, 
    Saludo, 
    CardComponent, 
    TarjetaComponent, 
    CommonModule,
  TodoComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent {
  /*title = 'Mi primera SPA';
  author = 'Javier Ramirez';
  perfil = 'Desarrollador Web';
  dato:number = 140*/
  isVisible = true;

  frutas = [
    "Manzana", 
    "Platano", 
    "Naranaja", 
    "Uva", 
    "Pera",
    "Piña"
  ];
}