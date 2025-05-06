import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ProductosComponent } from '../../Components/productos/productos.component';

@Component({
  selector: 'app-productos-info',
  imports: [ProductosComponent, CommonModule],
  templateUrl: './productos-info.component.html',
  styleUrl: './productos-info.component.css'
})
export class ProductosInfoComponent {
  items = [
    {id: 1, nombre:"Producto A", descripcion:"Descripción del producto A", precio: 100},
    {id: 2, nombre:"Producto B", descripcion:"Descripción del producto B", precio: 200},
    {id: 3, nombre:"Producto C", descripcion:"Descripción del producto C", precio: 300},
    {id: 4, nombre:"Producto D", descripcion:"Descripción del producto D", precio: 400}
  ];

  itemSeleccionado:any = null;

  seleccionarItem(item:any){
    this.itemSeleccionado = item;
  }

}