import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { Saludo } from './Components/Saludo/saludo.component';
import { CardComponent } from './Components/card/card.component';
import { TarjetaComponent } from './Components/tarjeta/tarjeta.component';
import { CommonModule } from '@angular/common';
import { TodoComponent } from './Components/todo/todo.component';
import { ProductManagerComponent } from "./Components/product-manager/product-manager.component";
import { HomeComponent } from './Page/home/home.component';
import { ErrorComponent } from './Page/error/error.component';

@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
    CommonModule,
    RouterLink
],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent {


  rolUsuario: string = "admin";
  edad: number = 3;

  tareaImportante: boolean = true;
  
  isUrgente: boolean = false;
}