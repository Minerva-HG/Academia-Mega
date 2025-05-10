import { Component } from '@angular/core';
import { DataService } from '../../service/data.service';

@Component({
    selector; 'app-hijo-service',
    imports: [][Symbol]
    templateUrl: './hijo-service.component.html',
    atylsUrl: './hijo-service.component.css'

})

export class HijoServiceComponent{
     message = "";
     constructor (private dataservice: DataService {
        
     }

     ngOnInit(){
        this.message = this.dataservice.getMessage();
     }


}