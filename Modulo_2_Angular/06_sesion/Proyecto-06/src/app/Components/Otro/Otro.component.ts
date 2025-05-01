import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-todo',
  imports: [FormsModule, CommonModule],
  templateUrl: './Otro.component.html',
  styleUrl: './Otro.component.css'
})
export class OtroComponent {
  nuevaTarea = "";

  tareas = [
    {texto: "Aprender Angular", completada: false},
    {texto: "Hacer ejercicio", completada: true}
  ];

  agregarTareas(){
    if (this.nuevaTarea.trim()){
      this.tareas
      .push({texto: this.nuevaTarea, completada: false});
      this.nuevaTarea = "";
    }
  }

  limpiarTareas(){
    this.tareas = [];
  }

  toggleCompletar(index: number) {
    this.tareas[index].completada = !this.tareas[index].completada;
  }

}
