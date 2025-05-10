import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-todo',
  imports: [FormsModule, CommonModule],
  templateUrl: './todo.component.html',
  styleUrl: './todo.component.css'
})
export class TodoComponent {
  nuevaTarea = "";

  tareas = [
    {texto: "Aprender Angular", completada: false},
    {texto: "Hacer Ejercicio", completada: true},
    {texto: "Comer 3 veces al día", completada: true},
    {texto: "Dormir 8 hrs", completada: false},
    {texto: "Ir con el nutriologo", completada: true},
    {texto: "Llamar a mis padres", completada: true},
    {texto: "Regar el jardín", completada: true},
    {texto: "Lavar la ropa", completada: true},
    {texto: "Comer frutas y verduras", completada: true},
    {texto: "Llenar las actividades", completada: true}
  ];

  agregarTareas(){
    if(this.nuevaTarea.trim()){
      this.tareas
      .push({texto: this.nuevaTarea, completada: false});
      this.nuevaTarea = "";
    }
  }

  limpiarTareas(){
    this.tareas = [];
  }

  toogleCompletar(index: number){
    this.tareas[index].completada = !this.tareas[index].completada;
  }
}
