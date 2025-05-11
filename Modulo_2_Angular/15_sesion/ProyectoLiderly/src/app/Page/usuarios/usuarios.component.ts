import { Component } from '@angular/core';
import { UserListComponent } from "../../components/user-list/user-list.component";
import { UserDetailComponent } from '../../components/user-detail/user-detail.component';


@Component({
  selector: 'app-usuarios',
  imports: [UserListComponent, UserDetailComponent],
  templateUrl: './usuarios.component.html',
  styleUrl: './usuarios.component.css'
})
export class UsuariosComponent {
  user:any;
}
