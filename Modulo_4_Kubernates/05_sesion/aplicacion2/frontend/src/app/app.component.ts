import { Component } from '@angular/core';
import { ItemListComponent } from "./components/item-list/item-list.component";

@Component({
  selector: 'app-root',
  imports: [ItemListComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'frontend';
}
