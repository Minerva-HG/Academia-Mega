import { Component } from '@angular/core';
import { HijoComponent } from '../../Components/hijo/hijo.component';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-home',
  imports: [HijoComponent, CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  //Simulación de API
  usuarios = [
    {nombre: "Javier", edad: 27, profesion: "Ingeniero"},
    {nombre: "Ana", edad: 29, profesion: "Diseñadora"},
    {nombre: "Luis", edad: 22, profesion: "Estudiante"},
    {nombre: "Omar", edad: 30, profesion: "Arquitecto"},
  ];

  mensajeDelHijo = "";
  recibiMensaje(mensaje: String){
    this.mensajeDelHijo = mensaje

  }


}
