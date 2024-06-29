import { Component, Input } from '@angular/core';
import { AdComponent } from '../ad/ad.component';

@Component({
  selector: 'app-infopane',
  templateUrl: './infopane.component.html',
  styleUrls: ['./infopane.component.css']
})
export class InfopaneComponent implements AdComponent{
  @Input() data: any;
  defaultImage: string = "/assets/Rolling1s60pxblueblack.gif";
}

