import { Routes } from '@angular/router';
import { CardComponent } from './components/card/card.component';
import { TodoComponent } from './components/todo/todo.component';
import { ProductManagerComponent } from './components/product-manager/product-manager.component';
import { HomeComponent } from './page/home/home.component';
import { ErrorComponent } from './page/error/error.component';
import { TarjetaComponent } from './components/tarjeta/tarjeta.component';
import { ProductosInfoComponent } from './page/productos-info/productos-info.component';
import { ServicePageComponent } from './page/service-page/service-page.component';
import { FormularioComponent } from './page/formulario/formulario.component';
import { ProductListComponent } from './page/product-list/product-list.component';
import { UsuariosComponent } from './page/usuarios/usuarios.component';

export const routes: Routes = [
  { path: '', component: UsuariosComponent },
  { path: 'apis', component: ProductListComponent },
  { path: 'formulario', component: FormularioComponent },
  { path: 'servicio', component: ServicePageComponent },
  { path: 'componentes', component: ProductosInfoComponent },
  { path: 'home', component: HomeComponent },
  { path: 'card', component: CardComponent },
  { path: 'todo', component: TodoComponent },
  { path: 'gestor', component: ProductManagerComponent },
  { path: 'tarjeta', component: TarjetaComponent},
  { path: '**', component: ErrorComponent }
];
