import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-tarjeta',
  imports: [FormsModule],
  templateUrl: './tarjeta.component.html',
  styleUrl: './tarjeta.component.css'
})
export class TarjetaComponent {
  nombre:string = "";
  imagen:string = "https://";
  mensaje:string = "¡Bienvenido!";
 
  cambiarSaludo(){
    this.mensaje = `¡Hola ${this.nombre || "visitante"}!`;
  }
}
