import { Routes } from '@angular/router';
import { CardComponent } from './components/card/card.component';
import { TodoComponent } from './components/todo/todo.component';
import { ProductManagerComponent } from './components/product-manager/product-manager.component';
import { HomeComponent } from './page/home/home.component';
import { ErrorComponent } from './page/error/error.component';
import { TarjetaComponent } from './components/tarjeta/tarjeta.component';
import { OtroComponent } from './components/Otro/Otro.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'card', component: CardComponent },
  { path: 'todo', component: TodoComponent },
  { path: 'gestor', component: ProductManagerComponent },
  { path: 'tarjeta', component: TarjetaComponent},
  { path: 'Otro', component: OtroComponent},
  { path: '**', component: ErrorComponent }
];
