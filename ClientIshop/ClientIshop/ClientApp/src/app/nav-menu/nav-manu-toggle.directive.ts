import { Directive, HostListener} from '@angular/core';

@Directive({
  selector: '[appNavManuToggle]'
})
export class NavManuToggleDirective {

  constructor() { }
  @HostListener('mouseleave') onMouseLeave() {
    console.log("mouseleave");
  }
  @HostListener('mouseenter') onMouseEnter() {
    console.log("mouseenter");
  }
}
