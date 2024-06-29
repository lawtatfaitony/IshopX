import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {

  volume1: number = 0;
  r: number = 10.2;
  constructor() {
    this.volume1 = Math.PI * Math.pow(this.r, 2);

    this.volume1 = Math.ceil(this.volume1);
  }

  ngOnInit() {
  }

}
