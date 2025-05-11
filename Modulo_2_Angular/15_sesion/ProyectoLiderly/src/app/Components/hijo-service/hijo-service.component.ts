import { DataService } from './../../service/data.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-hijo-service',
  imports: [],
  templateUrl: './hijo-service.component.html',
  styleUrl: './hijo-service.component.css'
})
export class HijoServiceComponent {
  message = "";

  constructor(private dataService: DataService) {}

  ngOnInit(){
    this.message = this.dataService.getMessage();
  }

  ngDoCheck(){
    this.message = this.dataService.getMessage();
  }
}
