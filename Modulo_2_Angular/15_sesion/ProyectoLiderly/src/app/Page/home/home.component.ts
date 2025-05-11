import { Component } from '@angular/core';
import { HijoComponent } from "../../components/hijo/hijo.component";
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home',
  imports: [HijoComponent, CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  usuarios = [
    {nombre: "Minerva", edad: 33, profesion:"Tester"},
    {nombre: "Javier", edad: 30, profesion:"Dev Muler"},
    {nombre: "Arturo", edad: 20, profesion:"Carpintero"},
    {nombre: "Carmen", edad: 50, profesion:"Maestra"},
    {nombre: "Carmen", edad: 50, profesion:"Maestra"},
  ]


  mensajeDelHijo: string = "";

  recibirMensaje(mensaje: string){
      this.mensajeDelHijo = mensaje;
  }

}
