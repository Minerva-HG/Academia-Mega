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
    {nombre: "Minerva", edad: 33, profesion: "QA"},
    {nombre: "Karla", edad: 29, profesion: "Mesera"},
    {nombre: "Carmen", edad: 22, profesion: "Maestra"},
    {nombre: "Joceline", edad: 30, profesion: "QFB"},
  ];
}
