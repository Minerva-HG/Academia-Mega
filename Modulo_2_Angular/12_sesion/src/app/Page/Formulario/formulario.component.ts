import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-formulario',
  imports: [FormsModule, CommonModule],
  templateUrl: './formulario.component.html',
  styleUrl: './formulario.component.css'
})
export class FormularioComponent {
  usuario = {
    nombre: '',
    email: '',
    edad: null
  };

  onSubmit(){
    console.log("Datos del Formulario: ", this.usuario);
    alert("Formulario enviado correctamente");
  }
}