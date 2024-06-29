
import { Component, Input} from '@angular/core';
import { AdComponent } from '../ad/ad.component';

@Component({
  selector: 'app-infovideopane',
  templateUrl: './infovideopane.component.html',
  styleUrls: ['./infovideopane.component.css']
})
export class InfovideopaneComponent implements AdComponent {
  @Input() data: any;
  constructor() { }
   
} 





