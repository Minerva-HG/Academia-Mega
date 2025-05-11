import { Component, Input} from '@angular/core';
import { CommonModule } from '@angular/common';
import { FullNamePipe } from '../../pipes/full-name.pipe';

@Component({
  selector: 'app-user-detail',
  imports: [CommonModule, FullNamePipe],
  templateUrl: './user-detail.component.html',
  styleUrl: './user-detail.component.css'
})
export class UserDetailComponent {
  @Input() user :| any;
}
