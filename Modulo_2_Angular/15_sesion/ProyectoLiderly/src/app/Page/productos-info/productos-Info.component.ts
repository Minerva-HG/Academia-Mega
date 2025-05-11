import { Component } from '@angular/core';
import { ProductosComponent } from "../../components/productos/productos.component";
import { CommonModule } from '@angular/common';
import { DetallesComponent } from '../../components/detalles/detalles.component';

@Component({
  selector: 'app-productos-info',
  imports: [ProductosComponent, CommonModule, DetallesComponent],
  templateUrl: './productos-info.component.html',
  styleUrl: './productos-info.component.css'
})
export class ProductosInfoComponent {

  items = [
    {id: 1, nombre: 'Producto A', descripcion: "Descripcion del producto A", precio:100},
    {id: 2, nombre: 'Producto B', descripcion: "Descripcion del producto B", precio:200},
    {id: 3, nombre: 'Producto C', descripcion: "Descripcion del producto C", precio:300},
    {id: 4, nombre: 'Producto D', descripcion: "Descripcion del producto D", precio:400},
  ];

  itemSeleccionado: any = null;

  seleccionarItem(item:any) {
    this.itemSeleccionado = item;

  }

}
