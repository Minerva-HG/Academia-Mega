import { Component } from '@angular/core';
import { RouterEvent, RouterLink, RouterOutlet } from '@angular/router';
import { CardComponent } from "./components/card/card.component";
import { TarjetaComponent } from "./components/tarjeta/tarjeta.component";
import { CommonModule } from '@angular/common';
import { TodoComponent } from "./components/todo/todo.component";
import { OtroComponent } from "./components/Otro/Otro.component";
import { ProductManagerComponent } from "./components/product-manager/product-manager.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CardComponent, TarjetaComponent, CommonModule, TodoComponent, ProductManagerComponent, RouterLink, OtroComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'ejemplo3';

  isVisible = true;
  frutas = ["Manzana", "Platano", "Naranja", "Uva", "Piña"];

  ///////////////////////
  rolUsuario = "admin";
  edad = 3;
  tareaImportante = true;
  isUrgente = true;

}
