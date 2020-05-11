import { Component, OnInit, Input } from '@angular/core';
import { ExtraDto } from '../../../classes/ExtraDto';

@Component({
  selector: 'app-extra-item',
  templateUrl: './extra-item.component.html',
  styleUrls: ['./extra-item.component.css']
})
export class ExtraItemComponent implements OnInit {
  @Input("extra") extra: ExtraDto;
  constructor() { }

  ngOnInit() {
  }

}
