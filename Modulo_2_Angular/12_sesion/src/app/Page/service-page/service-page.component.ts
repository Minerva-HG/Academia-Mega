import { Component } from '@angular/core';
import { formsModule } from '@angular/forms';
import { DataService } from '../../service/data.service';
import { HijoServiceComponent } from '../../Components/hijo-service/hijo-service.component';

@Component({
  selector: 'app-service-page',
  imports: [formsModule, HijoServiceComponent],
  templateUrl: './service-page.component.html',
  styleUrl: './service-page.component.css'
})
export class ProductosInfoComponent {
  message = "";

  constructor(private dataservice: DataService ){ }

  updateMessage (){
    this.dataservice.setMessage(this.dataservice);
  }
 
}